**LiteralLinq** is a library aiming to make original Linq function more dynamc by pure string parameter equivalent.

#Current Developing Status

Primary functions have been implemented. [Contact me](wengyuansheng@hotmail.com) if any bug found or have any new requirement. I'll reply soon.

#Target Of This Project

This project is inspired by [Scott Gu's blog](http://weblogs.asp.net/scottgu/archive/2008/01/07/dynamic-linq-part-1-using-the-linq-dynamic-query-library.aspx) about dynamically create expression tree against IQueryable objects.

In some scenarios, for instance, sorting datas against runtime-determined properties, original linq is too static as it's hard-coded in design time, in the end you must write a lot of boring if statement to make it seems "dynamic".

To solve the problems refered above, this project provide a way filtering or ordering a sequence with pure string parameters. You also need to notice that one trade off you must made is that any problem, such as misspelling, will only exposed in runtime.

#Downloading LiteralLinq

You can [download last version here](https://github.com/wengys/LiteralLinq/archive/master.zip) 

#Building LiteralLinq from sources

Just open the project with VS2012 or above and build.

#Usage

Add reference to LiteralLinq.dll, and add `using System.Linq;` in the top of source files.

Attention: Unlucky certain functions may not supported by all IQueryable provider. It's the problem of Linq, not me.

Read Examples first is recommended.

#Implemented Functions

1. OrderBy: Use string expression to order a sequence.
2. ThenBy
3. Where: Filtering sequence with string expression.

##OrderBy

### Parameter Format

path direction (, path direction)*

Path:
it(.property or paramless function call)* 
>1. "it": literal string represent an element in the source sequence. Self-referencing is allowed
>2. property: property in the source type that can be accessed
>3. function call: any paramless function with a return value

Direction:
>1. "ASC" or "DESC", this parameter is case insensitive. "ASC" if this parameter is omitted

And you can add more subsequent expressions seperated by leading comma. These subsequent expressions will treat as ThenBy expressions.

### Example

See `LiteralLinqTests\Linq\OrderByThenByTests.cs` for more details.

##ThenBy

Just same as OrderBy, except that it only applies ThenBy operation to source sequence.

##Where

### Parameter Format

path op1 value@formatter (op2 path op1 value@formatter )*

Path:
it(.property or paramless function call)* 
>1. "it": literal string represent an element in the source sequence
>2. property: property in the source element type that can be accessed
>3. function call: any paramless function with a return value

Op1:
Predefined operations.
>1. EQ: Equal, ==
>2. NE: Not equal, !=
>3. GT: Greater then, >
>4. LT: Less then, <
>5. GE: Greater then or equal, >=
>6. LE: Less then or equal, <=
>7. IN: In an array, only used against array values
>8. NOT IN: Not in an array, only used against array values
>9. LIKE: As LIKE operator in SQL, use "%" as place holder in string value's head, tail or both to search substring in the end, start or any location of the target

Value:
Support two kinds of values.
>1. Simple value: String surround with single quotes which can be converted to the type of target property or method's return value
>2. Array values: Simple values seperated by comma and surround with square brackets. Only support IN and NOT IN operators

Formatter:
String surround with single quotes indicating the format of the value string.

Op2:
Operator that connect two sub expressions. You can use parentheses to indicate the priority of expressions.
>1. AND
>2. OR

####Default Support Value Types 

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
13. DateTime: Default formatter is "yyyy-MM-dd"
14. char
15. bool
16. enum: Use enum value name as value string
17. Nullable value

####Custom type support

To add new type support, you need to implement 
`LiteralLinq.Expression.Design.ILiteralConverter` 
and regist this converter with 
`LiteralLinq.Linq.WhereExt.RegistConverter<T>(ILiteralConverter converter)`
as global converter or use 
`LiteralLinq.Expression.Design.LiteralConverterAttribute`
to decorate a class, a struct or a property.

To struct type, if you need to compare two struct value, make sure you have overrided relate operators (Such as == for equality compare).

###Example

See `LiteralLinqTests\Linq\WhereExtTests.cs` for more details.

#License

MS-PL license - [http://www.microsoft.com/en-us/openness/licenses.aspx](http://www.microsoft.com/en-us/openness/licenses.aspx)
