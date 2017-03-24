using SpecialApp.Entity;

namespace SpecialApp.Entity
{
    public class FileData : BaseEntity
    {
        public int Length { get; set; }

        public string ContentType { get; set; }

        public string UniqueFileName { get; set; }

        public string Path { get; set; }

        public byte[] Data { get; set; }

        public string OriginalFileName { get; set; }

        public string Title { get; set; }

        public bool IsUploaded { get; set; }

        public bool IsMarkedForDeletion { get; set; }

        public bool IsValidFileType { get; set; }
    }
}
