# CONTRIBUTING
A helpful file for development and contribution to the project.

##  Projects
This, and nearly all ASP.Net solutions, have three core parts:
### ZMS.Client
This is everything that will be on the client. This includes the UI, and any client-side logic.<br/>
Any and all scripts in this project will be run on the client, and not the server, reducing server load and enabling the creation of many client-side features.<br/>
### ZMS.Server
This is everything that will be on the server. This includes HTTP API, some server-rendered pages, and any extra server-side logic.<br/>
### ZMS.Shared
Shared files between the client and server.<br/>
Useful for enabling the client and server to share code, such as models, enums, and other logic.<br/>

##  Development
### Pages & Components
Pages and components are written in Razor, which is an html-like language, and would usually be located in the `Pages` and `Components` folders respectively, unless an other location makes more sense to use.<br/>
To specify that a component can be resolved to as a page, add `@page ""` to the top of the  file, and specify the route of this page in the parentheses.<br/>
Any component, regardless of whether it's a page or not, can be included in another component or page by using the `<ComponentName />` tag.<br/>
<details>
<summary>Notes & Examples</summary>

- Components can be nested within other components, and can be nested within pages.
- Components can have and be passed parameters, you can define parameters by adding `[Parameter]` above a public property in the component's class.
- Components will be sorted into a namespace, so if you think the namepsace will not be the same for a child component, change either namespace with the `@namespace` directive, or alternatively use the `@using` directive to import the namespace.<br/><br/>
Example of a component with a parameter: (properly commented so you can put it into actual scripts to check them out)
```razor
<!--We can call this file anything, but for now let's just remember "HelloName.razor"-->

<!--you can write code anywhere what is @-prefixed. This @Name will return the value of the Name property.-->
<h1>Hello, @Name!</h1>
<p>This is a really cool component!</p>

<!--@code {} defines a code block, and is where you can write C# code.-->
<!--Alternatively, you can write C# code an a nested .razor.cs file.-->
@code {
    <!--This is a parameter, and can be passed to the component.-->
    [Parameter] 
    public string Name { get; set; }
}
```

Example of a component being used in another component:
```razor
@page "/Looksie"
<!--This is a component or page that uses the HelloName component we remembered earlier.-->

<h1>Hey, what's up, welcome to my component-page!</h1>
<p>Here's a cool component that shows a name:</p>
<HelloName Name="Zak"></HelloName>
<p>Here's another one!<!p>
<HelloName Name="Marcel"></HelloName>

<!--It's useful to note that components dump elements directly into the parent element, and not into a container element such as a div.-->
<!--That means depending on how you want to use a component, the root element in that component should be a div.-->
```

By putting a component within another component, we've effectively just created:
```razor
@page "/Looksie"
<!--This is a component or page that uses the HelloName component we remembered earlier.-->

<h1>Hey, what's up, welcome to my component-page!</h1>
<p>Here's a cool component that shows a name:</p>
<h1>Hello, Zak!</h1>
<p>This is a really cool component!</p>
<p>Here's another one!<!p>
<h1>Hello, Marcel!</h1>
<p>This is a really cool component!</p>

<!--It's useful to note that components dump elements directly into the parent element, and not into a container element such as a div.-->
<!--That means depending on how you want to use a component, the root element in that component should be a div.-->
```
</details>

### Scripts
#### Client
Client scripts are written in C# instead of Javascript, though ASPNet does have a [good interop system](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-7.0).<br/>
These scripts can be included in the same .razor file as a page or component (any `.razor` file), or, more preferably, in a file with the same name, but instead with the extension of `.razor.cs`. This method is called a "nested structure."<br/>
<details>
<summary>Classes & Namepsaces for nested scripts</summary>

For nested scripts to work properly, the class must be a `partial` class, (showing that it's part of it's parent's class) and the namepsace must be the exact same as the components namespace. This will usually be `ZMS.Client.Pages`, `ZMS.Client.Components`, etc.<br/><br/>
As an Example, you'd have a file structure similar to this:
```
CallOfMinecraftWeb
├── ZMS.Client
│   ├── Pages
│   │   ├── PageName.razor
│   │   └── PageName.razor.cs
│   │       (The .cs file is nested within the .razor file)
|   └── ...
├── ZMS.Server
├── ZMS.Shared
...
```

In this case, the likely namespace for both of these files would default to `ZMS.Client.Pages`.<br/>
This means we can make our `PageName.razor` file look like this:
```razor
@page "/PageName"
@namepsace ZMS.Client.Pages <!--Enforce the expected namespace if required-->

<h1>Hey guys check out this cool page</h1>
<p>It's got a cool script in it!</p>
<p>It won't be in this file, though.</p>

<!--by prefixing with @, we can foreach elements into our page.-->
@foreach (string string in strings)
{
  <p>@string</p>
}

<!--demonstration of adding logic to an event-->
<button @onclick="IncrementNumber">You've clicked me @number times</button>
```
And our `PageName.razor.cs` file will look like this:
```csharp
namespace ZMS.Client.Pages
{
  //  If this isn't partial, and isn't the same class as the .razor file, it won't work.
  public partial class PageName
  {
    //  This is where we can put our script!
    //  Wow how cool!

    //  A list, that shows what I mean, but likely doesn't initialize properly.
    List<string> strings = new List<string>() {"Wow,", "I", "sure love", "lists!"};

    int number = 0;
  }

  public Async Task IncrementNumber()
  {
    number++;
  }
}
```
After having these two files made, rendered they form:
```razor
@page "/PageName"
@namepsace ZMS.Client.Pages <!--Enforce the expected namespace if required-->

<h1>Hey guys check out this cool page</h1>
<p>It's got a cool script in it!</p>
<p>It won't be in this file, though.</p>

<!--by prefixing with @, we can foreach elements into our page.-->
<p>Wow</P>
<p>I</P>
<p>sure love</P>
<p>lists!</P>

<!--demonstration of adding logic to an event-->
<!--For this demonstration, I assume you've pressed the button 69 times-->
<button @onclick="IncrementNumber">You've clicked me 69 times</button>
```

</details>

## Blog (News) System
The blog system is currently in the works. It will support Issues that embed articles.

I plan to have a in-app builder for issues and articles, but I have not gotten that far yet.

<details>
<summary>Creation of Issues</summary>

in `ZMS.Server\News\Issues`, Create a file with any name of your choosing. Avoid spaces and special characters.<br/>
The file extension should be .json, as we do not have any text in issues.

The file should look like this:
```json
{
  "Title": "Cool Issue!",
  "Thumbnail": "thumbnail-image.png",
  "Description": "Wow! So Cool, I think?",
  "Authors": [
    324588568951390220
  ],
  "Published": "2010-06-02T11:59:23.0404006-07:00",
  "Articles": [
    "HydroThunder",
    "Minecraft"
  ],
  "Path": "CoolIssue"
}
```
- Title & Description: These are the title and description of the issue. They can have as many spaces and special characters as you want.
- Thumbnail: This is a filename of an image in the `ZMS.Server\News\Media` folder.
- Authors: This is a list of Discord IDs of the authors of the issue. This will be used to show the authors of articles.
- Published: This is the date the issue was published. It must be in a Dotnet TimeDate compatible format.
- Articles: This is a list of articles in this issue. List must contain filenames of articles, and will render in the same order of the list.
- Path: This is the path of the issue. It must be the same as the title, but without the spaces or extension.

</details>

<details>
<summary>Creation of Articles</summary>

Articles are not much more complex than issues.<br/>
Each article has two files, a `.md` file, and a `.md.json` file.<br/>
The `.md` file is the actual article, and the `.md.json` file is the metadata for the article.<br/>

```json
{
  "title": "Article Title",
  "description": "So far, we're the same as an issue",
  "thumbnail": "thumbnail.png",
  "authors": [324588568951390220],
  "published": "2020-12-20"
}
```

The `.md` file, is a usual markdown file. No precaution is required, although this file and it's `.md.json` must have the exact same base name.

</details>