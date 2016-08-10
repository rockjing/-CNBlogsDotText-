.Text Clearscreen v1 Skin
by Miguel Jiménez ::: http://blogs.clearscreen.com/migs


1) Extract the contents of the ClearScreen.zip file into a folder named "ClearScreen01" in  the Skins folder of your .Text installation


2) Add the following lines of code to the Skins.config file located in the Admin folder of your .Text installation

   <SkinTemplate SkinID = "clearscreen" Skin="ClearScreen01" />
   <SkinTemplate SkinID = "clearscreen-pink" Skin="ClearScreen01" SecondaryCss="pink.css" />


3) If you want to add a graphic header to your blog, and remove the title and subtitle text, paste the following Custom Css Selectors in the Options -> Configure page of your blog's admin 

	.header {background-image:url('URL_OF_YOUR_IMAGE');}
	.headerText{display:none;}

   The image you specify will be added as a background to your header, so if should be wide enough to fulfil any possible screen-width; it also should have a 260 pixel padding on the left side.
   You have a HeaderTemplate.png file in this folder, where you can see the template of my own graphic header.
   Feel free to use the template to create your own, but don't copy my icon please! :)


4) Sometimes my IE or Mozilla use to don't find the xml icon in the left menu, and when reloading it will be found.
   If you want to stop this annoyance, edit the CategoryEntryList.ascx and replace the following:

	ImageUrl="../Images/xml.gif"
	
	with

	ImageUrl="/Skins/ClearScreen01/Images/xml.gif"  

	(note: before skin put any folder that should be added to access the file)



The use of this screen is totally free, and you can redistribuite it with or without permission if you provide the original package and keep the link to the skin download.

Any updates of this skin, as well as new secondary css will be posted at my blog http://blogs.clearscreen.com/migs

Contact me if you have any suggestion