namespace Stack
{
    public interface IStack<TElement>
    {
        void Push(TElement element);
 
        TElement Pop();
    }
}