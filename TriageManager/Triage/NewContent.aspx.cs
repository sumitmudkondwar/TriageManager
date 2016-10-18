using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using DataAccessLayer.Models;
using DataAccessLayer.BusinessLogic;
using System.IO;

namespace TriageManager.Triage
{
    public partial class NewContent : System.Web.UI.Page
    {
        //https://azure.microsoft.com/en-in/documentation/articles/storage-dotnet-how-to-use-blobs/
        // Retrieve storage account from connection string.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TriageContentLogic triageContentLogic = new TriageContentLogic();
                ddlHeading.DataTextField = "TopicName";
                ddlHeading.DataValueField = "SmeTopicsId";
                ddlHeading.DataSource = triageContentLogic.GetSMETopics();
                ddlHeading.DataBind();
            }
        }

        private void BlobCode()
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@"path\myfile"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        private void ListBlobs()
        {
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("photos");

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                    Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;

                    Console.WriteLine("Directory: {0}", directory.Uri);
                }
            }
        }

        private void DownloadBlobs()
        {
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

            // Retrieve reference to a blob named "photo1.jpg".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("photo1.jpg");

            // Save blob contents to a file.
            using (var fileStream = System.IO.File.OpenWrite(@"path\myfile"))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDescription.Text = string.Empty;
            flupNewFiles.Attributes.Clear();
            lblErrorMessage.Text = string.Empty;
            lblSuccessMessage.Text = string.Empty;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim().Equals(string.Empty) && flupNewFiles.HasFile == false)
            {
                lblErrorMessage.Text = "Either of Entering URL or File Upload is Mandatory!!!";
            }
            else
            {
                Guid guid = Guid.NewGuid();
                string FileNameList = "";
                FileNameList = UploadFilestoBlob(guid);

                TriageContent triageContent = new TriageContent();
                TriageContentLogic triageContentLogic = new TriageContentLogic();

                triageContent.SmeTopicsId = Convert.ToInt32(ddlHeading.SelectedItem.Value);
                triageContent.ContentLevel = Convert.ToInt32(ddlContentLevel.SelectedItem.Text);
                triageContent.ContentDescription = txtDescription.Text;
                triageContent.EmailId = "sumudk@microsoft.com";//HttpContext.Current.User.ToString();
                triageContent.FileNameList = FileNameList;

                triageContentLogic.AddNewContent(triageContent);

                txtDescription.Text = string.Empty;

                lblSuccessMessage.Text = "Content Successfully Added to KB.";
            }
        }

        private string UploadFilestoBlob(Guid guid)
        {
            string FileNameList = "";
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            CloudBlockBlob blockBlob;

            if (flupNewFiles.HasFile)
            {
                foreach (HttpPostedFile uploadedFile in flupNewFiles.PostedFiles)
                {
                    FileNameList = FileNameList + "|" + guid.ToString() + "_" + Path.GetFileName(uploadedFile.FileName);
                    blockBlob = container.GetBlockBlobReference(guid.ToString() + "_" + Path.GetFileName(uploadedFile.FileName));
                    blockBlob.UploadFromStream(uploadedFile.InputStream);
                }
            }

            return FileNameList;
        }
    }
}