**LiteralLinq** is a library aiming to make original Linq function more dynamc by pure string parameter equivalent.

##Current Developing Status

As this project is new, functions will added to it ASAP. Every existing function has tested and used in real project. And if anything go wrong, just [contact me](wengyuansheng@hotmail.com), I'll reply soon.

##Target Of This Project

This project is inspired by [Scott Gu's blog](http://weblogs.asp.net/scottgu/archive/2008/01/07/dynamic-linq-part-1-using-the-linq-dynamic-query-library.aspx) about dynamically create expression tree against IQueryable objects.

In some scenarios, for instance, sorting datas against random columns required by front end, original linq is hard to accomplish the task because it's parameters are given in code to get type checking at compile time or IntelliSense support ablilty. If you wish to just done these jobs with pure, easy to construct string parameter and lost type checking, this library is just for you. It's just a trade off you need to make.

##Downloading LiteralLinq

You can [download last version here](https://github.com/wengys/LiteralLinq/archive/master.zip) 

##Building LiteralLinq from sources

Just open the project and build. Then the built library can used anywhere.

##Implemented Functions

1. OrderBy

##OrderBy

### Parameter Format

keySelector direction (, keySelector direction)*
Where KeySelector:
it(.property or paramless function call)* 
>1. "it": literal string represent current item in source. 
>2. property: property in the source type that can be accessed.
>3. function call: any paramless function with a return value.
>4. direction: "ASC" or "DESC", case insensitive. "ASC" if not given.
>5. (, keySelector direction)*: following selector, apply ThenBy operation in one OrderBy call.

### Example

> `source.OrderBy("it");// source.OrderBy(it=>it);`
> `source.OrderBy("it DESC");// source.OrderByDescending(it=>it);`
> `source.OrderBy("it.PropertyA.PropertyB");// source.OrderBy(it=>it.PropertyA.PropertyB)`
> `source.OrderBy("it.MethodA()");// source.OrderBy(it=>it.PropertyA.PropertyB)`
> `source.OrderBy("it.MethodA().PropertyB");// source.OrderBy(it=>it.PropertyA.PropertyB)`
> `source.OrderBy("it.MethodA() ASC,it.PropertyB DESC,it.PropertyC");// source.OrderBy(it=>it.PropertyA.PropertyB).ThenByDescending(it=>it.PropertyB).ThenByDescending(it=>it.PropertyC)`

##License

MS=PL license - [http://www.microsoft.com/en-us/openness/licenses.aspx](http://www.microsoft.com/en-us/openness/licenses.aspx)
