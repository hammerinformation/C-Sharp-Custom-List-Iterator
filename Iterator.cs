using System.Collections.Generic;

public class Iterator<T>
{
    private List<T> list = new List<T>();
    private int position = -1;

    public T Current
    {
        get
        {
            position = position > list.Count - 1 ? list.Count - 1 : position < 0 ? -1 : position;
            return position != -1 ? list[position] : default;
        }
        set
        {
            position = position > list.Count - 1 ? list.Count - 1 : position < 0 ? -1 : position;

            if (position >= 0)
                list[position] = value;
        }
    }

    private Iterator(List<T> list)
    {
        this.list = list;
    }

    public static Iterator<T> operator +(Iterator<T> iter, int value)
    {
        iter.position += value;
        return iter;
    }

    public static Iterator<T> operator -(Iterator<T> iter, int value)
    {
        iter.position -= value;
        return iter;
    }

    public static Iterator<T> operator ++(Iterator<T> iter)
    {
        iter.position += 1;
        return iter;
    }

    public static Iterator<T> operator --(Iterator<T> iter)
    {
        iter.position -= 1;
        return iter;
    }

    public static implicit operator Iterator<T>(List<T> list)
    {
        return new Iterator<T>(list);
    }

    public static implicit operator int(Iterator<T> iter)
    {
        return iter.position == -1 ? 0 : iter.position;
    }

    public static implicit operator List<T>(Iterator<T> iter)
    {
        return iter.list;
    }

    public void SetPosition(int index)
    {
        index = index < 0 ? -1 : index > list.Count - 1 ? list.Count + 1 : index;
        position = index;
    }

    public bool Next()
    {
        var p = position;
        this.position += 1;
        return p < list.Count - 1;
    }

    public bool Prev()
    {
        var p = position;
        this.position -= 1;
        if (position == 0)
        {
            return true;
        }

        return p > 0;
    }

    public T Last() => list[^1];
    public T First() => list[0];
    public List<T> GetList() => list;

    public void Advance(int value)
    {
        position += value;
    }
}