# TerraChat
This was a group project at a C# and .Net course where we also used git, mssql and docker. 

2 people and I did the web client of the system (GiMeToMVCWeb)
I did the logic part and most of its design.
They did a little bit of the CSS and HTML part.

The structure is like this:
De.TerraChat.Base (Interfaces, etc.) -> Every team had to implement their respective parts from this.
De.TerraChat.Vitali (SQL handling logic) -> AndisAPIServer (API between SQL handler and Chat proxy)
AndisAPIServer <- De.TerraChat.ChrisLu (Chat proxy for Front End) <- GiMeToMVCWeb (Web client) OR TiTiMvcWEB (2nd team with another web client) OR DarnielsWPFClient (WPF client)
