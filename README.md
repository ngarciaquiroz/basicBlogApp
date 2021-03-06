# basicBlogApp
Blog
The site is currently available on https://basicblogapp.azurewebsites.net, the first load might take a bit longer than usual this is just because the WebApp is not as always running to prevent cost.

When you get to the site on the Index page you will be able to see all the published post (without comments), if you want to add a comment you can click on the title, this will take you to a single page where you can see and add Comments.

On the navigation you can see a Login option, there you can use either **writer** or **editor** the two available roles for the site, this will add a new option on the navigation Manage depending on the role you will see different things.

Writer:

Will get the Add Post button and a two lists: The first one for the posts on Draft (Saved but not on ready to publish) this list will display the content of the post and a Edit or Delete button. On the Edit page you can save your progess or submit for approval the post. (for the Rich text editor use images available online)

The second will include the posts that the writer already moved to pending for approval, you click on the title to see them but that's it.

Editor:

Is just a list with a review button this will take you to Edit view there you can either Publish or Reject the Post.

To test the endpoints i added swagger https://basicblogapp.azurewebsites.net/swagger/index.html
