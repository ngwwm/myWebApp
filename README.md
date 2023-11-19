# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. .

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)


# Manual Push changes to Azure Repo

git clone git@github.com:ngwwm/myWebApp.git s
cd s
git remote add azure https://mywebapp4free:h4phbawrxcxlpds3zjjsm65mnk6vwytoyh7fobu7v4peevidk3ba@dev.azure.com/mywebapp4free/MyWebApp/_git/MyWebApp
git checkout develop
git pull origin develop
git push azure develop

