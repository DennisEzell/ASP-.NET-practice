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
  <li>Setting the UserAgent and Aceept headers, this is to set it equal to the value sent back by the github API
    <ul>
      <li>webRequest.UserAgent = "DennisEzell"</li>
      <li>webRequest.Accept = "application/vnd.github.v3+json";</li>
    </ul>
  </li>
</ol>

### Step 3: Create the domain classes based on GitHub JSON 
<ol>
  <li>Go get the JSON response sample at https://api.github.com/events</li>
  <li>Using the <b>Web Essential</b> plugin within VS, go to Edit --> Paste As Special --> Paste JSON as Classes
    <ul>
      <li>This may not be needed since this will generate classes for all of the sample JSON</li>
      <li>This means multiple classes of the same type (user for example) will be generated if they differ by a single name/value pair</li>
    </ul>
  </li>
  <li>What we will probably do is just create POCOs that represent what we need from the JSON response
    <ul>
      <li>We will name our properties what we like and map them to the associated JSON property using: [JsonProperty("xx")]</li>
      <li>
      [JsonProperty("id")]<br>
        public string ID <br>
        {<br>
            get { return id; }<br>
            set { id = value; }<br>
        }<br>
      </li>
    </ul>
  </li>
  <li><b>**Update**</b> Using the program located at http://jsonclassgenerator.codeplex.com/downloads/get/631627, we can create our classes individually
    <ul>
      <li>The Git Hub events all have the same format with only the Payload differing.</li>
      <li>The Payload will differ based on the EventType</li>
      <li><b>Strategy For genrating our classes:</b> 
          <ul>
            <li>Use the application above to generate a base class on a sample JSON response (empty payload)</li>
            <li>Make subclasses that create a custom implementaion of the payload based on each distinct event type</li>
          </ul>
      </li>
    </ul>
  </li>  
</ol>

### Step 4: Parse the Git Hub response
<ol>
  <li>Parse the JSON response by using the NewtonSoft.JSON assembly</li>
  <li>We use the Newtonsoft.Json.JsonConvert.Deserialize&lt&gt() method
      <ul>
        <li>This method takes a string representation of the JSON response</li>
        <li>You specify the object to map to by providing it in the parameter brackets</li>
        <li>EX: var gitEvents = JsonConvert.DeserializeObject&ltIEnumerable&ltGitEvent&gt&gt(read.ReadToEnd())</li>
        <li></li>
      </ul>
  </li>
</ol>


# Appendix
## Creating .gitIgonre
<ol>
  <li>Open the local directory where you cloned your repo</li>
  <li>Shift + Right click and select "Open Git Bash here"</li>
  <li>Enter $git touch .gitignore</li>
  <li>Edit the new .gitignore to inlcude the following</li>
    <ul>
      <li>*/Dashboard/Generated/*/li>
      <li>*/Dashboard/Properties/*</li>
      <li>*/Dashboard/obj/*</li>
    </ul>
    <li>This will ignore any files generated when creating a Publish profile</li>
</ol>

## Deploying to Azure
<ol>
  <li>Inside VS right click the project (under the sln name, "Dashboard" for this project)</li>
  <li>Click "Publish"</li>
  <li>Select "Microsoft Azure Web Apps"</li>
  <li>It will show the account you are logged into VS as and any subscription</li>
    <ul><li>I did not have a subscription</li></ul>
  <li>Go to https://portal.azure.com/ </li>
  <li>Enter you microsoft account info you logged into VS with</li>
  <li>You will be redirected to the Azure Dashboard</li>
  <li>Setup free Azure subscription</li>
    <ul>
      <li>On the left hand navigation menu, scroll to the very bottom option of <b>More services &gt </b></li>
      <li>On the resulting new menu, click <b>Subscriptions</b></li>
      <li>On the new menu, clic the top left option of <b>+ Add</b></li>
      <li>You will be redirect to the subscription screen, select <b>Free Trail</b></li>
      <li>Complete the verification steps</li>
    </ul>
 </ol>

## Deploying to Google Cloud 
### Create and configure a new Compute Engine instance
<ol>
	<li>Create a Google Cloud account at https://cloud.google.com/</li>
	<ul>
		<li>I did this implicitly since I was in google chrome logged in to my Google account</li>
	</ul>
	<li>First, use the Google Cloud Launcher to create a new <b>Compute Engine</b> instance that has Windows Server 2012 R2, Microsoft IIS, ASP.NET, and SQL Express preinstalled</li>
	<li>In the Cloud Platform Console, go to the Cloud Launcher ASP.NET Framework page.</li>
		<ul>
			<li><b>Note:</b> If this is your first time using Compute Engine, the Compute Engine API will initialize before you arrive at the page. The initialization process can take up to a minute to complete.</li>
		</ul>
	<li>Set your deployment name and preferred Compute Engine zone.</li>
	<li>Click Deploy ASP.NET Framework to deploy the instance.</li>
		<ul>
			<li><b>Note:</b> Windows instances can take up to eight minutes to deploy.</li>
		</ul>
	<li></li>
	<li></li>
</ol>
### Add default windows user
<ol>
	<li>After the deployment process finishes, add a default Windows user to your new instance</li>
	<li>In the Cloud Platform Console, go to the VM instances page.</li>
	<li>Click the name of your newly deployed instance. If you used the default deployment settings, the instance name will have the prefix aspnet.</li>
	<li>On the instance page, click Create or reset Windows password.</li>
	<li>In the Set new Windows password dialog, add your username, and click Set to create the user account on your instance.</li>
	<li>Make a note of the provided password, and close the dialog.</li>
</ol>
