# ziglu-tt

Notes
● Using xBehave instead of specflow, have assumed only technical people would be reading and potentially writing the tests with input form stakeholders, specflow is a bit heavy/bloated/unneeded in my opinion?
● Removed the console application because the ITestOutputHelper in xunit writes anything out to test output for anyone to see (run tests inside your IDE of choice to see the output, if you run dotnet test from the test directory you’ll only see output if tests fail)
● Was quite difficult to write tests because it’s a third party API integration? Test boundaries etc… Have tried as much as possible to test things in the ziglu service (our domain)
● Didn’t have time to add the docker compose file
● Didn’t have time to write the JSON to describe myself unfortunately but happy to discuss that face to face!
     
email questions/comments to richard@developerintest.dev

technical excercise repo for ziglu

Ziglu Automation

Create a backend automation framework using the following API:

https://www.coingecko.com/en/api

(You will need to create an account on rapidapi.com, this will give you an API key to run the tests)

To create the account head over to https://rapidapi.com/coingecko/api

The user journeys to automate:

Features - 

. Get the 3 top exchanges based upon trust score and output to console the findings, be sure to include the relevant information associated to these requests
. Get the top 5 exchange trading volumes for bitcoin in the last 24 hours and sort these
. Get the following 3 coins Dynamite, Venus, Rivermount - Return the price comparison against GBP, include the following data as well - market cap,  24hr GBP price change and the last updated time

Bonus 
. Lastly, for all the coins above - get the coins and retrieve the amount of twitter users they have following them

● Please create your framework in C# using a BDD framework - things to consider -  CI/CD  - Dockerizing the project
● Once you have finished, please upload the framework to a private GitHub repo and give me access to it (tommy.verrall@ziglu.io - GH tommyvziglu)
● Please add a README which contains information on how we should set up our run the tests

Questions
• How long did you spend on the technical test? What would you add to your solution if you had more time? If you didn't spend much time on the technical test then use this as an opportunity to explain what you would add
• What do you think is the most interesting trend in test automation?
• Please describe yourself using JSON
