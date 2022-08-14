namespace MyCampusUI.Utils
{
    public class ItemRef<T>
    {
        public event EventHandler? ItemChanged;

        private T item;
        public T Item
        {
            get => item;
            set
            {
                item = value;
                ItemChanged?.Invoke(this, new EventArgs());
            }
        }

        public ItemRef(T item)
        {
            this.item = item;
        }
    }
}
