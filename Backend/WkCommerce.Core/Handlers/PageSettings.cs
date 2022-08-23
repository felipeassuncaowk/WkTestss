namespace WkCommerce.Core.Handlers
{
    public class PageSettings
    {
        public PageSettings() : this(0, 20)
        {
        }

        public PageSettings(int index, int size, long? total = null)
        {
            Index = index;
            Size = size;
            Total = total;
        }

        public int Index { get; private set; }

        public int Size { get; }

        public long? Total { get; }

        public int GetOffset() => (Index - 1) * Size;

        public PageSettings Next()
        {
            return Next(Size, Total);
        }

        public PageSettings Next(int size, long? total = null)
        {
            return new PageSettings(++Index, size, total);
        }

        public PageSettings Current(long total)
        {
            return new PageSettings(Index, Size, total);
        }
    }
}