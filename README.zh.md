**LiteralLinq** 提供了几个常用的Linq方法重载的纯字符串参数版本，从而扩展原生的Linq方法，方便动态操作数据。
#当前开发状态

主要功能已经完成。如果发现了什么BUG或者想加入什么新功能，请[猛戳这里](wengyuansheng@hotmail.com)。我会尽快回复的。

#项目目标

本项目起源于[Scott Gu的博客](http：//weblogs.asp.net/scottgu/archive/2008/01/07/dynamic-linq-part-1-using-the-linq-dynamic-query-library.aspx)上动态创建代码树以操作IQueryable对象的博客文章。

在某些时候，比如需要根据运行时确定的属性进行排序时，原生的Linq由于需要编译的原因而过于静态化。这时就只能写一堆神烦无比的if判断来解决问题了。

本项目正是通过使用纯字符串形式的参数，以实现动态地对数据进行排序、筛选，从而解决上述问题。

使用者使用前必须权衡下是否接受失去编译时类型检查所带来的风险。

#下载LiteralLinq

[猛戳这里下载最新版本代码](https：//github.com/wengys/LiteralLinq/archive/master.zip)。

#编译源码

使用VS2012以上版本打开并生成。

#使用LiteralLinq

引用LiteralLinq.dll， 并在使用到的代码文件头部加上`using System.Linq;`。

注意： 不是所有的IQueryable provider都支持下叙所有功能。这都是~~时辰~~Linq的错。

个人严重推荐使用前先把示例代码看遍。

#已实现功能

1. OrderBy：通过字符串进行排序。
2. ThenBy
3. Where：通过字符串进行筛选。

##OrderBy

###参数格式

路径 排序方向 (，路径 排序方向)*

路径：
it(.属性或无参方法调用)* 
>1. "it"：表示序列中的一个元素
>2. 属性：序列中元素的某个属性
>3. 方法调用：序列中元素的某个具有返回值的无参方法

排序方向：
>1. "ASC" or "DESC"， 本参数大小写不敏感。如果忽略的话默认ASC

可以通过逗号隔开以增加多组表达式，后续表达式都用于ThenBy排序。

###示例代码

参见`LiteralLinqTests\Linq\OrderByThenByTests.cs`。

##ThenBy

和OrderBy一样，不过所有表达式都用于ThenBy排序。

##Where

###参数格式

路径 运算符1 值@值格式 (运算符2 路径 操作符1 值@值格式 )*

路径：
it(.属性或无参方法调用)* 
>1. "it"：表示序列中的一个元素
>2. 属性：序列中元素的某个属性
>3. 方法调用：序列中元素的某个具有返回值的无参方法

运算符1：
预定义的运算符。
>1. EQ：相等（Equal），同==
>2. NE：不等（Not equal），同!=
>3. GT：大于（Greater then），同>
>4. LT：小于（Less than），同<
>5. GE：大等（Greater then or equal），同>=
>6. LE：小等（Less then or equal），同<=
>7. IN：在数组中，只对数组值类型有效
>8. NOT IN：不在数组中，只对数组值类型有效
>9. LIKE：与SQL的LIKE云算符类似，使用 "%"作为占位符放置在字符串值的头部、尾部或头尾，以匹配字符串的尾部、头部或任意位置

值：
支持两种类型的值。
>1. 简单值类型： 单引号包裹的字符串，字符串格式必须支持转换为对应的属性或方法返回值的格式
>2. 数组值类型， 处于方括号中并用逗号分隔开的简单值数组，只支持IN和NOT IN运算符

值格式：
单引号包裹的用于表明简单值字符串格式的字符串。

运算符2：
用于连接两个子表达式的运算符。可用括号表明表达式优先级。
>1. AND：与，两个子表达式需要同时成立。同&&
>2. OR：或，两个表达式之一需要成立。同||

####默认支持类型

1. byte
2. Int16
3. Int32
4. Int64
5. sbyte
6. UInt16
7. UInt32
8. UInt64
9. float
10. double
11. decimal
12. string
13. DateTime： 默认使用的值格式为"yyyy-MM-dd"
14. char
15. bool
16. enum： 使用枚举值名
17. 可空类型（Nullable类型）

####增加新类型支持

您需要实现
`LiteralLinq.Expression.Design.ILiteralConverter`
来创建格式转换器，并使用
`LiteralLinq.Linq.WhereExt.RegistConverter<T>(ILiteralConverter converter)`
以注册全局转换器，或者使用 
`LiteralLinq.Expression.Design.LiteralConverterAttribute`
来修饰class、struct或者一个属性。

当增加struct支持时，如果需要比较两个struct的值，需要预先重载相应云算符（如重载==以比较两个struct值）。

###示例代码

参见`LiteralLinqTests\Linq\WhereExtTests.cs`。

#协议

MS-PL 协议 - [http：//www.microsoft.com/en-us/openness/licenses.aspx](http：//www.microsoft.com/en-us/openness/licenses.aspx)
