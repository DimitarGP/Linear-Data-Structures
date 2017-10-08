using System;

public class ArrayList<T>
{
    private const int InitialCapacity = 2;
    private T[] data;

    public ArrayList()
    {
        this.data = new T[InitialCapacity];
    }

    public int Count { get; set; }

    public T this[int index]
    {

        get
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.data[index];
        }

        set
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.data[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.data.Length)
        {
            ResizeArray();
        }
        this.data[Count] = item;
        this.Count++;
    }

    private void ResizeArray()
    {
        T[] newArr = new T[this.Count * 2];
        Array.Copy(this.data,newArr,Count);
        this.data = newArr;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.data[index];

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.Count--;
        if (this.Count <= data.Length /4)
        {
            Srink();
        }
        return element;
    }

    private void Srink()
    {
        T[] copy = new T[this.data.Length / 2];
        for (int i = 0; i < copy.Length; i++)
        {
            copy[i] = this.data[i];
        }

        this.data = copy;
    }
}
