ZedGraph官网地址：https://sourceforge.net/projects/zedgraph/files/

PaneList中实现通过名字去查找是可以借鉴的

```C#
 public GraphPane this[string title]
 {
     get
     {
         int num = IndexOf(title);
         if (num >= 0)
         {
             return base[num];
         }

         return null;
     }
 }

public int IndexOf(string title)
{
    int num = 0;
    using (Enumerator enumerator = GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            if (string.Compare(enumerator.Current.Title.Text, title, ignoreCase: true) == 0)
            {
                return num;
            }

            num++;
        }
    }

    return -1;
}
```

反编译chm文件方法：hh.exe -decompile D:\LiuChen_Person\Files\学习资料 D:\LiuChen_Person\Files\学习资料\ZedGraph Help.chm