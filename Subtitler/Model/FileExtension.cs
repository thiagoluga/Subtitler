using System;

namespace Subtitler.Model
{
    public class FileExtension : IEquatable<FileExtension>
    {
        public string Name { get; set; }

        public string Value 
        {
            get { return $".{Name}"; }
            set { }
        }

        public string ValueWithWildcard
        {
            get { return $"*.{Name}"; }
            set { }
        }

        public int Code { get; set; }

        public bool Equals(FileExtension other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Code.Equals(other.Code) && Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashProductName = Name == null ? 0 : Name.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = Code.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }

        public override string ToString() { return this.Name; }
    }
}
