# TerraChat
This was a group project at a C# and .Net course where we also used git, mssql and docker. 

2 people and I did the web client of the system (GiMeToMVCWeb).\
I did the logic part and most of its design.\
They did a little bit of the CSS and HTML part.\
\
The structure is like this:\
De.TerraChat.Base (Interfaces, etc.) -> Every team had to implement their respective parts from this.\
De.TerraChat.Vitali (SQL handling logic) -> AndisAPIServer (API between SQL handler and Chat proxy)\
AndisAPIServer <- De.TerraChat.ChrisLu (Chat proxy for Front End) <- GiMeToMVCWeb (Web client) OR TiTiMvcWEB (2nd team with another web client) OR DarnielsWPFClient (WPF client)

We all had a time window of about 3 hours to finish this project.\
Therefore mistakes are most likely going to be visible here and there.

Here is how our team's part looks like. A demo.:

![welcoming_page](https://user-images.githubusercontent.com/20255127/171928950-5184d5c9-c6f9-4bf6-8c4b-df56390ec3e0.png)
![chatfenster](https://user-images.githubusercontent.com/20255127/171928958-0d84dd91-0c76-43b0-8904-19c728c2e7a5.png)
