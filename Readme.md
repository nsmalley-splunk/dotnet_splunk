This is a simple app built in .Net that showcases how to leverage the Splunk SDK and the Splunk HTTP Event Collector Endpoint to send data. 

This is built to showcase how data can come from a .Net Core program 

In this please adjust the Docker File to account for your HTTP Event Collector Details 
Host
Port
HEC Token 

Once done you should be able to execute the docker compose and it should run the program sending the data in JSON format. From there how you would like the data split up is up to you, Metric for Perf Metrics and Log for Application Start Stop
