namespace SharpKernelUpdate.App.Model
{
	public class KUUrlItem
	{
		string fullName;
		string[] splitName;
		string uri;
		string filePath;
		string fileName;
		bool isReady;

		public string FullName
		{
			get
			{
				return fullName;
			}

			set
			{
				fullName = value;
			}
		}

		public string[] SplitName
		{
			get
			{
				return splitName;
			}

			set
			{
				splitName = value;
			}
		}

		public string Uri
		{
			get
			{
				return uri;
			}

			set
			{
				uri = value;
			}
		}

		public string FilePath
		{
			get
			{
				return filePath;
			}

			set
			{
				filePath = value;
			}
		}

		public string FileName
		{
			get
			{
				return fileName;
			}

			set
			{
				fileName = value;
			}
		}

		public bool IsReady
		{
			get
			{
				return isReady;
			}

			set
			{
				isReady = value;
			}
		}
	}
}
