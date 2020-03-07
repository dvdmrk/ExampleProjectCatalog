# Week 1

## Requirements:
Think of an idea and create a project plan.

## Expectation:

At the end of this class you will have a GitHub repo for your project. You should come to class with an idea and spend class coding your plan as part of the README.md file. Consult the [GitHub Markdown Cheat Sheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet) for questions regarding how to use Markdown. 

Your Project Plan should consist of the following fields:

- **Overview -** A brief overview of what your program does
- **Technical Summary -** A brief technical summary of what technologies your project implements
- **Getting Started -** A brief instructional on how to build and run your application
- **Features -** A brief overview of the high level features your application implements
- **Milestones -** A list of tasks you will need to accomplish to complete this project

Consult the following examples for previous successful project plans:

- [Example Project Catalog](https://github.com/dvdmrk/ExampleProjectCatalog)
- [Real Estate Project](https://github.com/jsaucedo294/cl_realEstateProject)

---

## Getting Started

1. **Come up with an idea**

Before you can come up with an idea it helps to have an idea of what we'll be building. The requirements want us to build an MVC CRUD application. MVC is a design pattern that will be covered in [Week 2](). CRUD stands for: Create, Read, Update, and Delete. **Basically-** we're going to build a website that controls a multidimensional excel sheet. To put that in different words: we are building the user interface to access and augument data.

**Simply Put:** You're going to build a front-end, backend, and database.

What are some good ideas for this?

- Movie catalog
- Quote catalog
- Attendance sheet
- To-do list
- Workout tracker

You are going to build the user interace, logic, and database- so your idea should involve data you care about, logic you understand, and a topic you're interested in designing around. 

When I start a new project, I like to think about, "what problem do I want to solve?" When I went through this course, the problem I wanted to solve was keeping track of personal training clients, so I built an MVC CRUD application to keep track of everyones progress. As the mentor of this course and author of these tutorials, I'm anticipating the problem of keeping track of everyones progress, so I'm going to build an MVC CRUD application for tracking everyones milestones. 

---

2. **Create a GitHub Repository**

If this is your first foray into VCS I've written a pervious article on [Getting started with Git](https://davewritescode.com/blog/getting-started-with-git/). The previous article is only recommended if you have not yet registered a GitHub or have forgotten how to create a repository. In this step you should create a new repository, clone the new repo, add a README.md file, input your project plan, and push to master.

If you're looking for a more advanced way to do this, I prefer to use the GitHub API. Curl is required for this. You can install Curl with Chocolatey packagemanager using <code>chco install curl</code>

<details>
<summary>Expand this if you want to know how to create a GitHub repo with code</summary>

Substitute anything inside of the square brackets with your values. You will be asked for your password.

```curl
curl -u [Your GitHub Username] https://api.github.com/user/repos -d "{\"name\":\"[Name of your desired repository]\", \"description\": \"[Description of your desired repository] \"}"
```

This will allow you to then perform the command <code>git clone https://github.com/[Your GitHub Username]/[Your newly created Repository name]</code>

</details>

---

3. **Write your README.md**

After navigating to your repository folder you can use the commands <code>echo >> README.MD</code> and <code>code .</code> to create a README.md file and open Visual Studio Code. If you haven't yet configured your development environment take a read over my article on [New Developer Machine Configurations](https://davewritescode.com/blog/new-developer-machine-setup-guide/).

If you are following this tutorial to the 'T', your README.md should look a lot like [mine](https://github.com/dvdmrk/ExampleProjectCatalog/blob/master/README.md), but you should consult your mentor to determine if your idea fits the criteria and if these articles can help you achieve your milestones. 

---

4. **Push to GitHub**

I will be explicitly outlining my branching strategy and organization throuhout this course, but if that annoys you feel free to ignore it and implement your own. 

Now that you've got your: Idea Invented, Repo Created, README Written, you need to push. Use the following three commands to add your changes, create a commit, and push to master.

```
git add .
git commit -m "Initial Commit/ Added README"
git push -u origin master