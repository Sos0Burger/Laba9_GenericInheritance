internal class Program
{
    private static void Main(string[] args)
    {
        User Tom = new User("Tom", "12356");
        User Bob = new User("Bob", "654321");

        User.loginArray.print();
        User.passArray.print();

    }
}

class User
{
    public static LoginArray loginArray = new LoginArray();
    public static PassArray passArray= new PassArray();
    public User(string login, string pass)
    {
        loginArray.add(login);
        passArray.add(pass);
    }
}


class LoginArray : GenericArray<string>
{
    public LoginArray(params string[] mass) : base(mass)
    {

    }
}

class PassArray : GenericArray<string>
{
    public PassArray(params string[] mass) : base(mass)
    {

    }
}


class GenericArray<T>
{
    T[] array;

    public GenericArray(params T[] mass)
    {
        array = mass;
    }

    public void add(T item)
    {
        T[] newArray = new T[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[array.Length] = item;
        array = newArray;
    }
    public void delete(T item)
    {
        T[] newArray = new T[array.Length - 1];
        int j = -1;
        bool wasDeleted = false;
        for (int i = 0; i < array.Length; i++)
        {
            j++;
            if (array[i].Equals(item) && !wasDeleted)
            {
                wasDeleted = true;
                j--;
                continue;
            }
            newArray[j] = array[i];
        }
        array = newArray;
    }
    public void print()
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public T get(int index)
    {
        return array[index];
    }
    public int getLength()
    {
        return array.Length;
    }
}