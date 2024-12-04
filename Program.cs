// See https://aka.ms/new-console-template for more information

using EfCoreTester;

using var db = new BloggingContext();
db.Database.EnsureCreated(); // Creates the db (don't do this in a real app)
// Create
Console.WriteLine(db.DbPath);
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();