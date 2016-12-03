# ASP .NET practice
Repo holding a simple ASP .NET MVC app to experiment with various C# functions


### Step 1: Create git repo and check in project
<ol>
  <li>Created new git repo </li>
  <li>Clone this repo into a local directory that VS will be creating the new .NET project within
    <ul>
      <li>I created a new directory to hold my new git repo on my local </li>
      <li>I created the new directory at C:\Users\Deeze814\Source\Repos </li>
    </ul>
  </li>
  <li>I then Shift+Right Click to open a git bash terminal in this directory and issued the commands
    <ul>
      <li>git clone https://github.com/DennisEzell/DotNET_practice.git
        <ul>
          <li>This will create a new folder in the Dashboard directory named after the repo being cloned</li>
          <li>Results in a path of C:\Users\Deeze814\Source\Repos\DotNET_practice\</li>
        </ul>
      </li>      
    </ul>
  </li>
  <li>Then I opened Visual Studios and performed the following steps:
    <ul>
      <li>Click File --> New --> Project</li>
      <li>Popup Left Menu:   Templates --> Visual C#</li>
      <li>Popup Right Menu:  ASP.NET Web Application</li>
      <li>Popup Bottom Menu: Following values-->
          <ul>
            <li>Name:           Dashboard</li>
            <li>Location:       C:\Users\Deeze814\Source\Repos\DotNET_practice\</li>
            <li>Solution:       Create new Solution</li>
            <li>Solution Name:  Dashboard</li>
          </ul>
      </li>
      <li>On the next screen I selected the MVC option</li>
    </ul>
  </li>
  <li>Open Git bash and path down into the cloned repo location (C:\Users\Deeze814\Source\Repos\DotNET_practice)</li>
  <li>Run the following Git commands
    <ul>
      <li>$ git pull</li>
      <li>$ git add *</li>
      <li>$ git commit -m "Initial commit of C# project"</li>
      <li>$ git push</li>
    </ul>
  </li>
</ol>
  
### Step 2: Issue request to public GitHub public event API
<ol>
  <li>I had to cast the WebRequest to a HttpWebRequest in order to set the UserAgent:
    <ul><li>var webRequest = (HttpWebRequest)WebRequest.Create(apiUrl)</li></ul>
  </li>
  <li>Setting the UserAgent, this is to set it equal to the value sent back by the github API
    <ul><li>webRequest.UserAgent = "application/vnd.github.v3+json"</li></ul>
  </li>
  <li></li>
</ol>
    
        
