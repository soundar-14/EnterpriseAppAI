---
Title: EnterpriseAppAI Chat History Import
ImportedFrom: C:\Users\SoundararajanThangav\.copilot\session-state\bd157bdc-5fa7-4bf2-8d61-3ec1e2442c8c\files\paste-1784720848942.txt
ImportedAt: 2026-07-22T16:50:44.844+05:30
---


























If you're already a Senior/Lead .NET Developer and want to build AI applications, RAG (Retrieval-Augmented Generation) is one of the highest-ROI skills to learn. Since you already know C#, APIs, SQL, and Angular, focus less on ML theory and more on building end-to-end RAG systems.

Phase 1: Understand LLM Fundamentals (2–3 days)
Learn
What is an LLM?

Tokens

Context window

Temperature

Prompt Engineering

Hallucinations

Function Calling

Structured Output

Outcome
You should be able to answer:

Why do LLMs hallucinate?

Why can't ChatGPT know my private documents?

What is context length?

Phase 2: Learn Embeddings (3–4 days)
Understand

Text
↓

Embedding Model

↓

Vector
Example

"I love .NET"

↓

[0.23, -0.18, 0.92, ....]
Learn

What are embeddings?

Similarity Search

Cosine Similarity

Dot Product

Euclidean Distance

No mathematics is required beyond understanding the concepts.

Phase 3: Learn Vector Databases (4–5 days)
Popular databases

Pinecone

Qdrant

ChromaDB

Weaviate

Azure AI Search

PostgreSQL + pgvector

For .NET developers, a good sequence is:

ChromaDB (easy)

Qdrant

Azure AI Search

Learn

Collections

Upsert

Search

Metadata filtering

Top K search

Phase 4: Understand the RAG Pipeline (Most Important)
The pipeline is:

PDF

↓

Chunking

↓

Embedding

↓

Vector DB

↓

User Question

↓

Embedding

↓

Similarity Search

↓

Top Documents

↓

LLM

↓

Answer
Learn every step.

Phase 5: Chunking Strategies
Different strategies include:

Fixed-size chunking

Recursive chunking

Sentence chunking

Semantic chunking

Sliding window chunking

Questions to answer:

Why not store an entire PDF as one chunk?

What is chunk overlap?

What chunk size works best?

Phase 6: Build Your First RAG
Example:

Company HR Policy PDF

↓

Ask

"How many casual leaves do I get?"

↓

Answer from PDF
Use

ASP.NET Core Web API

Angular

OpenAI

ChromaDB

Phase 7: Learn Semantic Kernel
Since you're a .NET developer, this is an excellent next step.

Topics

Kernel

Chat Completion

Embedding Generation

Memory

Plugins

Function Calling

Planner

Agents

Phase 8: Learn Microsoft AI Stack
Learn

Azure OpenAI

Azure AI Search

Azure Document Intelligence

Azure Blob Storage

Azure AI Foundry

This is the stack used in many enterprise AI projects.

Phase 9: Advanced RAG
Topics

Hybrid Search

BM25

Semantic Search

Re-ranking

Multi-query retrieval

Query rewriting

Metadata filtering

Parent-child retrieval

Context compression

Multi-vector retrieval

Phase 10: Production RAG
Learn

Prompt templates

Caching

Streaming responses

Conversation memory

Cost optimization

Token management

Logging

Monitoring

Evaluation

Security

Guardrails

Projects to Build (in order)
Project 1
PDF Chat

Upload PDFs and ask questions.

Skills:

Embeddings

Chunking

Vector DB

Project 2
Employee Handbook Assistant

Features:

HR policies

Leave rules

Insurance

Holidays

Project 3
Codebase Assistant

Upload:

.NET solution

Angular project

Ask:

"Explain Authentication."

"Where is Dependency Injection configured?"

"Which APIs call SQL?"

Project 4
Interview Knowledge Assistant

Upload:

C#

SQL

Angular

Azure notes

Build your own interview preparation chatbot.

Project 5
Enterprise Document Search

Upload:

Word

Excel

PDFs

Images (using OCR)

Ask natural language questions across all documents.

Tools to Learn
Category    Recommended Tool
LLM    OpenAI GPT-4.1 / GPT-5 family, Azure OpenAI
Embeddings    OpenAI Embeddings
Vector DB    Qdrant, ChromaDB, Azure AI Search
Backend    ASP.NET Core
Frontend    Angular
Framework    Semantic Kernel
OCR    Azure Document Intelligence
Storage    Azure Blob Storage
Monitoring    Langfuse, OpenTelemetry
Suggested 8-Week Learning Plan
Week    Focus
1    LLM fundamentals, prompts, tokens
2    Embeddings, vector search, cosine similarity
3    ChromaDB/Qdrant and similarity search
4    Build a basic RAG chatbot with PDFs
5    Semantic Kernel and tool/function calling
6    Azure AI Search, Document Intelligence, Blob Storage
7    Advanced retrieval techniques (hybrid search, reranking, metadata filtering)
8    Production-ready RAG: streaming, security, evaluation, observability
Since you're a .NET Lead
A strong enterprise-focused stack would be:

Angular

↓

ASP.NET Core Web API

↓

Semantic Kernel

↓

Azure OpenAI

↓

Azure AI Search

↓

Azure Blob Storage

↓

Azure Document Intelligence

↓

Application Insights / OpenTelemetry
This combination aligns well with modern enterprise AI applications and is commonly requested in .NET + Azure roles.

Once you're comfortable with this stack, you can move on to AI Agents, Model Context Protocol (MCP), Agent-to-Agent (A2A) communication, multi-agent systems, and GraphRAG, which build naturally on top of RAG concepts.


can we go practical sementic kernal with openAI for our enterpise application?

Yes, we can. In fact, this is the perfect time because you've completed the .NET foundation and now understand the AI fundamentals.

However, I want to make one adjustment to our learning path.

❌ I don't want to build "Hello AI"
Most tutorials do this:

Console App

↓

Call Azure OpenAI

↓

Print "Hello"
or

ASP.NET

↓

Ask "Tell me a joke"

↓

Done
You'll learn very little from that.

✅ We'll build it directly into EnterpriseAppAI
Our first AI milestone will look like this:

Angular (Later)

↓

OpenAPI

↓

ChatController

↓

IChatService

↓

ChatService

↓

Semantic Kernel

↓

Azure OpenAI

↓

Response
This is the minimum enterprise architecture.

Then we'll gradually grow it
Milestone 1 (Today)
User

↓

ChatController

↓

Semantic Kernel

↓

Azure OpenAI

↓

Response
Simple chat.

Milestone 2
System Prompt

↓

Conversation History

↓

Azure OpenAI
You'll learn Prompt Engineering.

Milestone 3
Employee Plugin

↓

Semantic Kernel

↓

Function Calling
Ask:

Find employee EMP001.

Milestone 4
Document Upload

↓

Azure AI Search

↓

RAG
Ask:

Explain maternity leave policy.

Milestone 5
IT Plugin

↓

Create Ticket
Ask:

Create VPN issue.

Milestone 6
HR Plugin

↓

Leave Request
Ask:

Apply leave for tomorrow.

Milestone 7
AI Agents

↓

HR Agent

↓

IT Agent

↓

Knowledge Agent
Everything builds on what came before.

This is the Architecture We'll End Up With
                   Enterprise Copilot

                           │

                           ▼

                    ChatController

                           │

                           ▼

                     IChatService

                           │

                           ▼

                     ChatService

                           │

                           ▼

                    Semantic Kernel

      ┌──────────────┬───────────────┬───────────────┐
      ▼              ▼               ▼               ▼

 Azure OpenAI   Employee Plugin   HR Plugin   IT Plugin

                                             │

                                             ▼

                                      Azure AI Search

                                             │

                                             ▼

                                        RAG Documents
This isn't a demo—it's a realistic enterprise architecture.

I Want to Improve Our Learning Even More
Instead of saying:

Today we'll install Semantic Kernel.

We'll do this:

Lesson Structure
Part 1
Concept

Part 2
Enterprise Architecture

Where it fits.

Part 3
Coding

Only after understanding.

Part 4
Testing

Verify it works.

Part 5
Interview Questions

What interviewers ask.

Part 6
Production Best Practices

How real enterprise applications are built.

🚀 So What Are We Building Today?
Today's milestone is:

Integrate Semantic Kernel into EnterpriseAppAI and connect it to Azure OpenAI to make your first real AI request through your existing ChatController.

That means we'll go from:

ChatController
      │
      ▼
Placeholder Response
to:

ChatController
      │
      ▼
ChatService
      │
      ▼
Semantic Kernel
      │
      ▼
Azure OpenAI
      │
      ▼
Real AI Response
Before We Start Coding
I need one thing from you because it determines the exact implementation.

Which of these do you have?
Azure OpenAI resource already created (endpoint + deployment + API key)

An Azure subscription, but no Azure OpenAI resource yet

Neither (we'll create everything from scratch)

Once you tell me which situation you're in, we'll begin the practical implementation using the correct setup for your environment. This keeps the project aligned with the enterprise architecture we've been building.


I have azure subscription only and guide me one by one steps and now I am doing manually not by copilot so don't miss any concepts and please refer previous conversion also. I want to lean and implement clearly for all concepts

Perfect. This is actually the best situation to be in.

You have an Azure subscription, but we'll build everything ourselves. That means you'll learn not only the .NET code but also how to provision and configure Azure resources—the same skills expected in enterprise projects.

I also want to make a commitment for the rest of this project.

How We'll Work From Now On
I reviewed the journey we've taken so far. Earlier, I was giving you implementation tasks quickly. Going forward, we'll slow down and make sure you understand every concept before writing code.

For every topic, we'll follow this structure:

Concept – What is it?

Problem – Why does it exist?

Alternatives – What else could we use?

Enterprise architecture – Where does it fit?

Implementation – We code it manually together.

Testing – Verify it works.

Best practices – Production considerations.

Interview questions – Common questions and answers.

How it connects to the next topic – So you always see the bigger picture.

We're going to treat this as a real enterprise mentoring program, not a tutorial.

Final Architecture We'll Build
Our target architecture is:

                Enterprise Copilot

                       │

                       ▼

                Angular UI (Later)

                       │

                       ▼

                ASP.NET Core API

                       │

                       ▼

                ChatController

                       │

                       ▼

                 IChatService

                       │

                       ▼

                  ChatService

                       │

                       ▼

                Semantic Kernel

        ┌──────────────┼────────────────┐
        ▼              ▼                ▼

 Azure OpenAI      Plugins         Memory

        │              │
        │              ├── Employee
        │              ├── HR
        │              ├── IT
        │              └── Documents
        │
        ▼

 Azure AI Search (RAG)

        │

 SQL Server / Blob Storage
Notice that nothing we've built so far is wasted. Every layer you've already implemented remains useful.

Phase 5 Plan
We'll split it into small lessons.

Lesson 2.1 – Azure OpenAI Resource
Concept

What is Azure OpenAI?

What is a Resource?

What is a Model?

What is a Deployment?

Why are they separate?

Enterprise Task

Create Azure OpenAI resource.

Deploy a chat model.

Obtain endpoint and API key.

Coding

None.

Lesson 2.2 – Connect Semantic Kernel
Install packages.

Register Kernel.

Configure DI.

Connect to Azure OpenAI.

Lesson 2.3 – First AI Response
Replace the placeholder in ChatService with a real response from Azure OpenAI through Semantic Kernel.

Lesson 2.4 – Prompt Engineering
System prompt.

Conversation history.

Execution settings.

Lesson 2.5 – Function Calling
Connect AI to your Employee module.

Lesson 2.6 – RAG
Connect AI to your Documents module.

Everything builds incrementally.

Today's Goal
We are not writing code yet.

We are going to create the Azure resources correctly.

This usually takes 15–20 minutes and is the foundation for everything else.

Lesson 2.1 – Azure OpenAI
First Concept
Many beginners think this:

Azure OpenAI

↓

GPT-4.1
Actually, Azure has several layers:

Azure Subscription

↓

Resource Group

↓

Azure OpenAI Resource

↓

Model Deployment

↓

Your Application
Each has a different responsibility.

What is an Azure Subscription?
Think of it as your Azure billing account.

It owns everything you create.

What is a Resource Group?
Think of it as a project folder.

Everything related to EnterpriseAppAI should be inside one resource group.

Example:

EnterpriseAppAI-RG
Later it will contain:

Azure OpenAI

Azure AI Search

Storage Account

Key Vault

Application Insights

Keeping them together makes management much easier.

What is an Azure OpenAI Resource?
This is not the model.

This resource provides:

Authentication

Endpoint

Security

Networking

Monitoring

Think of it as the service endpoint your application connects to.

What is a Model?
Examples include:

GPT-4.1

GPT-4.1-mini

GPT-4o

GPT-4o-mini

Text embedding models

A model is the AI itself.

What is a Deployment?
This is one of the most important Azure OpenAI concepts.

In Azure, you deploy a model and give it your own deployment name.

For example:

Model:

GPT-4.1-mini
Deployment Name:

enterprise-chat
Your application will call:

enterprise-chat
—not "GPT-4.1-mini".

This lets you switch to another model later without changing your application code.

Why Use Deployment Names?
Imagine today you deploy:

enterprise-chat

↓

GPT-4.1-mini
Six months later you want:

enterprise-chat

↓

GPT-4.1
The deployment name stays the same, so your code doesn't change.

That's an excellent enterprise design principle.

Your Assignment (Today's Only Task)
Don't create anything yet.

First, answer these three questions in your own words:

What is an Azure OpenAI Resource?

What is a Model?

Why does Azure use a Deployment Name instead of having applications call the model directly?

Once you've answered those, we'll move to the Azure Portal together and create:

A Resource Group.

An Azure OpenAI resource.

Your first chat model deployment.

We'll do each step together and I'll explain every option in the portal so you understand not only what to click, but why you're choosing it.


ok give me steps to all for our application with practical

Absolutely. From this point onward, we'll build EnterpriseAppAI exactly as if you had joined a real enterprise AI project on Day 1.

I also want to set one expectation: I don't want to rush to the final application. The goal is not just to make it work—it's for you to understand every architectural decision so that, by the end, you can design a similar system yourself.

🎯 Our Goal (2-Month Capstone)
We're not building a chatbot.

We're building an Enterprise Service Management Copilot.

Users will eventually be able to ask:

"How many leave days do I have?"

"Create an IT ticket."

"Summarize the HR leave policy."

"Who is my reporting manager?"

"Show all employees in Engineering."

"Reset my VPN password."

"Create a laptop request."

"What is our travel reimbursement policy?"

To support these capabilities, we'll gradually add:

Employee module

HR module

IT Service Desk

Documents

RAG

AI Agents

MCP

Memory

Function Calling

🗺️ Complete Roadmap
This is the roadmap we'll follow.

Phase 1 – .NET Foundation ✅ Completed
You've already completed:

Clean Architecture

CQRS

MediatR

Repository

Unit of Work

EF Core

JWT

Logging

Validation

Employee CRUD

Chat architecture

No changes needed.

Phase 2 – AI Foundation (Current)
This is where we are now.

Lesson 2.1
Azure OpenAI Fundamentals
Learn

Azure OpenAI

Resource

Model

Deployment

Endpoint

API Key

Practical

Create Azure resources.

No coding yet.

Lesson 2.2
Semantic Kernel
Learn

Kernel

Plugins

Prompt execution

Why SK exists

Alternatives

Practical

Install packages.

Register Kernel.

Dependency Injection.

Lesson 2.3
Connect Azure OpenAI
Practical

Replace placeholder with real AI.

ChatController

↓

ChatService

↓

Semantic Kernel

↓

Azure OpenAI
Lesson 2.4
Prompt Engineering
Learn

System Prompt

User Prompt

Chat History

Temperature

Max Tokens

Practical

Improve chat quality.

Lesson 2.5
Conversation Memory
Learn

Stateless vs stateful conversations

Chat history

Context management

Practical

Persist conversations.

Phase 3 – Function Calling
We'll start using your existing business modules.

Employee Plugin
Questions like:

Find employee EMP001
HR Plugin
Leave balance
IT Plugin
Create ticket
Now AI starts invoking your own application logic.

Phase 4 – Documents
We'll add:

Document upload

Blob Storage

Metadata

Categories

Still without AI.

Phase 5 – RAG
We'll learn:

Chunking

Embeddings

Vector Search

Azure AI Search

Citations

Users will ask:

"What is our maternity leave policy?"

The AI will answer using your uploaded HR documents.

Phase 6 – AI Agents
We'll create:

HR Agent

IT Agent

Knowledge Agent

Each will use the services we've already built.

Phase 7 – MCP
We'll expose enterprise tools through the Model Context Protocol and discuss how AI systems can interact with external capabilities in a standardized way.

🏗️ Enterprise Architecture
By the end, your application will look like this:

                   Enterprise Copilot

                          │

                     Angular UI

                          │

                          ▼

                    ASP.NET Core API

                          │

                          ▼

                    ChatController

                          │

                          ▼

                     IChatService

                          │

                          ▼

                      ChatService

                          │

                          ▼

                    Semantic Kernel

        ┌──────────────┬──────────────┬───────────────┐
        ▼              ▼              ▼               ▼

 Azure OpenAI    Employee Plugin   HR Plugin    IT Plugin

                                               │

                                               ▼

                                        Azure AI Search

                                               │

                                               ▼

                                           Documents

                                               │

                                               ▼

                                        SQL Server
📅 Today's Practical Work
We'll only do Lesson 2.1.

Step 1 – Create Azure Resources
We will create:

Azure Subscription
        │
        ▼
Resource Group
        │
        ▼
Azure OpenAI Resource
        │
        ▼
Model Deployment
Step 2 – Verify
We'll collect:

Endpoint

API Key

Deployment Name

Nothing else.

Step 3 – Stop
No coding today.

Because I don't want you to create resources without understanding what they represent.

🚀 How We'll Work
From now on, every lesson ends with a working EnterpriseAppAI.

For example:

Lesson 2.3 ends with:

POST /api/chat

↓

Azure OpenAI

↓

Real Response
Lesson 2.5 ends with:

Conversation Memory
Lesson 3 ends with:

Employee Plugin Working
So after every lesson, your application gains a real enterprise capability.

First Practical Step
Let's begin with the Azure portal.

Sign in to the Azure portal.

Once you're on the home page, tell me:

Do you already have Azure AI Foundry available in your subscription?

Or is this a brand-new Azure subscription with no AI resources?

We'll use that information to decide the most appropriate way to provision your Azure OpenAI resource, because the experience can differ slightly depending on your subscription and available services. This will be our first real enterprise infrastructure task before we write any AI integration code.


I did sign in portal and showing microsoft foundry menu what should I do next?

Excellent! You're at the right place. Microsoft has shifted toward Azure AI Foundry for creating and managing Azure AI resources, so we'll use that. This is also the direction most new enterprise projects are taking.

Lesson 2.1 – Create Azure OpenAI for EnterpriseAppAI
Today's Learning Objectives
By the end of today, you'll understand:

✅ What Azure AI Foundry is

✅ What a Hub (or AI Project) is

✅ What an Azure OpenAI resource is

✅ What a deployment is

✅ How EnterpriseAppAI will connect to it

No coding today—only infrastructure and concepts.

First Concept: What is Azure AI Foundry?
Think of it like this:

Visual Studio
        │
        ├── C#
        ├── ASP.NET Core
        ├── SQL Projects
        └── Azure Projects
Visual Studio is not C#—it's a place to build applications.

Similarly:

Azure AI Foundry
        │
        ├── Azure OpenAI
        ├── Azure AI Search
        ├── Prompt Flow
        ├── Evaluations
        ├── Agents
        └── Models
Azure AI Foundry is not the AI model.

It is Microsoft's development and management environment for AI applications.

Later, we'll use it to manage:

Azure OpenAI

AI Search

Prompt testing

Agents

Evaluations

EnterpriseAppAI Future
Eventually, you'll have:

EnterpriseAppAI

↓

Azure AI Foundry

↓

Azure OpenAI
Azure AI Search
AI Agents
Prompt Flow
So learning Foundry now is the right approach.

Step 1 – Open Azure AI Foundry
From the Azure Portal:

Click:

Azure AI Foundry

It should open a page where you can create or manage AI projects.

Step 2 – Tell Me What You See
Don't click Create yet.

Tell me which screen you're on.

For example, is it something like:

Create AI Project

Create Hub

Projects

Models

Overview

Or upload a screenshot if you're unsure.

Why I'm Asking You to Pause
Many tutorials tell you to click Next → Next → Finish.

I don't want that.

I want you to understand every Azure resource we create.

When we create something, I'll explain:

What it is

Why we're creating it

Why EnterpriseAppAI needs it

Whether we'll use it immediately or in a later phase

That way, every Azure resource has a clear purpose in your architecture instead of being "just another service."

👉 Reply with the screen you're currently seeing (or share a screenshot), and we'll proceed one step at a time.


I got overview this ""Innovate Anywhere with AI
Build intelligent apps faster using prebuilt and custom models, scalable infrastructure, and tools optimized for developers and data teams.
Create a Foundry Resource
Create a Foundry Resource
Start building a Foundry resource to start building, customizing and evaluating AI solutions using Foundry.
Create a resource
Manage AI Resources
Manage AI Resources
View and manage all your AI services.
View all resources
Explore Best Practices and Guidance
Explore Best Practices and Guidance
Learn how to securely design, deploy, and manage AI solutions.""

Perfect. 👍 You're on the Overview page. This is exactly where we should start.

Don't worry—we're not going to blindly click Create Resource. First, let's understand what we're creating.

Lesson 2.1 – Step 1: Understand the Azure Resources
Think of Azure resources like building a house.

Azure Subscription
        │
        ▼
Resource Group
        │
        ▼
Azure AI Foundry Resource
        │
        ▼
Azure OpenAI Model Deployment
        │
        ▼
EnterpriseAppAI
Each layer has a different responsibility.

1️⃣ Azure Subscription
You already have this.

It is simply your Azure account that owns and bills all the resources.

Example:

Soundararajan Subscription
2️⃣ Resource Group
Think of it as your project folder.

For our project we'll create something like:

EnterpriseAppAI-RG
Later it will contain:

Azure AI Foundry

Azure OpenAI

Azure AI Search

Storage Account

Key Vault

Application Insights

Everything related to your application stays together.

3️⃣ Azure AI Foundry Resource
This is NOT the AI model.

Many beginners think:

Foundry = GPT
That's incorrect.

Foundry is the place where you:

Manage AI resources

Test prompts

Deploy models

Create agents

Connect AI Search

Evaluate responses

It's similar to how Visual Studio helps you build applications but isn't the application itself.

4️⃣ Azure OpenAI Model
This is the actual AI.

Examples include:

GPT-4.1

GPT-4.1-mini

GPT-4o

GPT-4o-mini

Embedding models

Your application never talks directly to "GPT-4.1".

Instead, Azure asks you to create a deployment.

5️⃣ Deployment
Suppose we deploy:

Model:
GPT-4.1-mini
Deployment Name:

enterprise-chat
Our application will call:

enterprise-chat
If Microsoft releases a better model later, we can point enterprise-chat to the new model without changing our code. That's a great enterprise design practice.

🏗️ How This Fits Into EnterpriseAppAI
When we're finished, the flow will be:

EnterpriseAppAI

↓

ChatService

↓

Semantic Kernel

↓

Azure OpenAI

↓

Deployment

↓

GPT Model
Notice:

Semantic Kernel doesn't know which model is behind the deployment.

Your application doesn't know either.

It only knows the deployment name.

This loose coupling is intentional.

✅ Practical Step 2
Now let's create our first resource.

Click:

Create a resource

After you click it, stop and tell me exactly what the next screen shows.

It might ask you to choose:

AI Foundry Resource

Project

Hub

Azure AI Foundry

AI Services

The exact options can vary depending on your subscription and the current Azure portal experience.

📸 A screenshot is even better if you're unsure.

🎯 Why We're Going Slowly
I know you asked for "one by one" guidance.

That's exactly what we'll do.

By the time we finish this project, you'll know not just how to create Azure resources, but also why each one exists and how it supports your Enterprise Service Management Copilot. That's the level of understanding expected from a Lead .NET developer working on enterprise AI solutions.


I used to create foundry ""
Create a Foundry resource
Basics
Storage
Inbound Networking
Outbound Networking
Identity
Encryption
Tags
Review + create
View automation template
Basics
Subscription
Visual Studio Professional Subscription
Resource group
rg-enterprise-app-si
Name
enterprise-foundry
Region
South India
Default project name
enterprise-app
Storage
Key Vault
Application Insights
Storage for Agents service
0 item(s)
Storage Account (preview)
Inbound Networking
Inbound Access
All networks, including the internet, can access this resource.
Outbound Networking
Network isolation mode for Agent
No Outbound Networking
Identity
Identity type
System assigned""

Excellent! 🎉 You're at the Create Azure AI Foundry Resource page. This is exactly where we want to be.

Before you click Next, let's understand every field. This is how senior engineers approach cloud resources—they know why each option exists.

Current Screen: Basics
1. Subscription
Visual Studio Professional Subscription
What is it?
Your Azure billing account.

Every Azure resource belongs to one subscription.

For our project:

Visual Studio Professional Subscription
        │
        ├── Resource Groups
        ├── Virtual Machines
        ├── Azure AI
        ├── SQL Database
        └── Storage
✅ Yours is correct.

2. Resource Group
rg-enterprise-app-si
What is a Resource Group?
Think of it as a project folder.

rg-enterprise-app-si

├── Azure AI Foundry
├── Azure AI Search
├── Storage
├── Key Vault
├── App Insights
└── SQL Database
Everything for EnterpriseAppAI should live here.

Recommendation: If this resource group is dedicated to this learning project, it's perfect. Otherwise, create a new one such as:

rg-enterprise-app-ai
or

rg-enterpriseappai
This keeps the project isolated.

3. Name
enterprise-foundry
Perfect.

Later you'll see:

enterprise-foundry
inside Azure.

4. Region
South India
Excellent.

Why Region Matters
Azure resources live in a physical datacenter.

Examples:

South India

Central India

East US

West Europe

For performance, it's usually best to keep related resources in the same region whenever possible.

Later we'll create:

Azure AI Search

Storage Account

Key Vault

Prefer the same region if the required services are available there.

5. Default Project Name
enterprise-app
This is the default AI project created inside the Foundry resource.

We'll use it later for:

Prompt testing

Agent development

Model playground

Evaluations

You can keep it.

Notice the Next Tabs
You have:

Storage
Inbound Networking
Outbound Networking
Identity
Encryption
Tags
Each one is important.

Storage
You'll probably see:

Key Vault
Application Insights
Storage
These are created automatically.

Why?
Key Vault
Stores secrets securely.

Examples:

API Keys

Database passwords

Connection strings

Instead of:

{
  "ApiKey":"123456"
}
you'll eventually use:

Key Vault

↓

Application

↓

Secret
Much more secure.

Application Insights
Logs:

Exceptions

AI latency

Request duration

Performance

We'll use this much later.

Storage Account
Used by many Azure services.

Later:

Documents

Images

AI Agent files

may all live here.

Inbound Networking
Current:

All Networks
For learning, this is fine.

In a production enterprise, you would often restrict access using private networking.

Outbound Networking
No Outbound Networking
We'll keep the default for now.

Networking is an advanced topic we can revisit later.

Identity
System Assigned
This is excellent.

We'll discuss Managed Identity later.

Instead of storing passwords, Azure services can authenticate to each other using identities managed by Azure.

Don't Click "Review + Create" Yet
We still need to inspect the Storage tab before creating the resource.

Your Next Step
👉 Click Storage.

Then tell me what you see.

Specifically, I'd like to know:

Is Key Vault set to "Create new" or "Use existing"?

Is Application Insights set to "Create new" or "Use existing"?

Is Storage Account set to "Create new" or "Use existing"?

Or simply share a screenshot of the Storage tab.

We'll review those settings together before creating the resource. After the Foundry resource is ready, we'll move on to deploying the chat model that your EnterpriseAppAI will use.


Today 1:09 PM
should select anything?

Good question. For our learning project, don't select anything extra unless we explicitly need it. We want to keep the setup simple and understand each service before adding more infrastructure.

Here's what I recommend.

Storage Tab
You should see something similar to:

Key Vault

Application Insights

Storage for Agents service

Storage Account (Preview)

✅ Key Vault
If it says Create new, keep Create new.

Why?

Today we don't need it.

Later we'll store:

Azure OpenAI API Key

Azure AI Search Key

Storage connection strings

Enterprise applications should not keep secrets in appsettings.json.

✅ Application Insights
Keep Create new.

Why?

Later we'll monitor:

AI response time

Token usage

Errors

Performance

This is very common in production.

✅ Storage for Agents Service
Do not configure it now (leave it empty/default).

Why?

We are not building AI Agents yet.

We'll configure it in the AI Agents phase.

✅ Storage Account (Preview)
Leave it unchecked / don't create it now (unless Azure makes it mandatory).

Why?

We'll create a dedicated Storage Account later when we build the Documents module and RAG.

At that time, I'll explain:

Blob Storage

Containers

SAS Tokens

Private Access

Lifecycle policies

Creating it now doesn't provide any benefit for our current phase.

Summary
Setting    What to do    Why
Key Vault    ✅ Create new    Store secrets later
Application Insights    ✅ Create new    Monitoring and diagnostics
Storage for Agents    ⏸ Leave default    Needed in a later phase
Storage Account (Preview)    ⏸ Don't create now (unless required)    We'll build it during the Documents/RAG phase
One Important Question
Before clicking Review + Create, could you share a screenshot of the Storage tab?

The Azure portal changes frequently, and I want to verify the exact options you're seeing so we choose the correct settings for your subscription instead of relying on assumptions. This will help us avoid creating unnecessary resources or missing a required option.


I didn't create in storage then next?

Perfect. ✅ That's the right decision.

Now let's continue one step at a time.

Current Status
You've completed:

✅ Basics

✅ Storage (left defaults / didn't create optional storage)

Now move to:

Step 3 – Inbound Networking
What should you choose?
For learning, keep:

✅ All networks
Why?
Your local laptop (Visual Studio) needs to call Azure OpenAI.

Flow:

Your Laptop
      │
      ▼
Internet
      │
      ▼
Azure OpenAI
If you choose Private Network, your local machine won't be able to connect without additional Azure networking (VPN, Private Endpoint, VNet, etc.).

Enterprise Note
Later, in a production company, you'll often use:

Virtual Network

↓

Private Endpoint

↓

Azure OpenAI
That prevents public internet access. We'll discuss this when we cover enterprise security.

Step 4 – Outbound Networking
Keep the default:

No Outbound Networking
Don't change anything.

Step 5 – Identity
Keep:

System Assigned Managed Identity
Why?
This creates an Azure-managed identity for the resource.

Later, instead of storing secrets like:

{
  "ApiKey": "xxxxxxxx"
}
Azure services can authenticate securely using Managed Identity.

We'll use this concept when we integrate services like Azure AI Search and Key Vault.

Step 6 – Encryption
Keep the default settings.

We don't need customer-managed encryption keys for this learning project.

Step 7 – Tags
Leave them empty for now.

In enterprise environments, tags are useful for:

Cost tracking

Environment (Dev/Test/Prod)

Team ownership

Project name

We'll introduce them later if needed.

Step 8 – Review + Create
Now click:

Review + Create

Don't click Create immediately.

Wait for the validation to finish.

Tell Me
What do you see after validation?

Examples:

✅ Validation passed

❌ Some warning

❌ Some error

If there are any warnings or errors, copy them here or share a screenshot. We'll resolve them before creating the resource.

One More Suggestion
As we build this application, I'd also like to explain the Azure architecture alongside the .NET architecture.

For example, after creating this resource, we'll draw a diagram like:

EnterpriseAppAI (.NET)

↓

Semantic Kernel

↓

Azure OpenAI Resource

↓

Deployment

↓

GPT Model
This will help you understand both the application flow and the cloud infrastructure together, which is how enterprise AI solutions are typically designed.


Today 2:22 PM
ok I understood. what is next step?

Excellent! I'm glad you're taking the time to understand the concepts instead of just clicking through the portal. That will pay off later when we get to RAG, AI Agents, and MCP.

Before We Continue
I have one question:

Have you actually clicked "Create" and waited for the Azure AI Foundry resource deployment to complete?

If Yes, our next step is to create the Azure OpenAI model deployment.

If No, click Create now and wait until Azure shows:

Deployment succeeded
Then click Go to resource.

Next Step: Create Your First Model Deployment
Now comes one of the most important Azure OpenAI concepts.

What We've Created So Far
Azure Subscription
        │
        ▼
Resource Group
        │
        ▼
Azure AI Foundry Resource
But notice...

❌ We still don't have an AI model.

It's like buying a laptop without installing Windows.

We Need to Deploy a Model
Think of it this way:

Azure AI Foundry Resource
          │
          ▼
Model Catalog
          │
          ▼
Deploy Model
          │
          ▼
Deployment Name
Your application never calls the model directly.

It calls the deployment.

Why Azure Uses Deployments
Suppose today:

Deployment Name

enterprise-chat

↓

GPT-4.1-mini
Six months later:

Deployment Name

enterprise-chat

↓

GPT-4.1
Did your application change?

No.

It still calls:

deploymentName = "enterprise-chat";
Only Azure changed which model sits behind that deployment.

This is a great example of loose coupling, a design principle you're already familiar with from dependency injection.

EnterpriseAppAI Architecture
After this step, our architecture becomes:

EnterpriseAppAI

↓

ChatController

↓

ChatService

↓

Semantic Kernel

↓

Azure OpenAI Endpoint

↓

Deployment
   │
   ▼
GPT-4.1-mini
Later, we can swap GPT-4.1-mini for GPT-4.1 without changing our application code.

Your Next Practical Task
After the resource deployment succeeds:

Open your Azure AI Foundry resource.

Launch the Azure AI Foundry portal (if prompted).

Look for one of these options (the wording can vary):

Model Catalog

Models

Deployments

Deploy model

Don't deploy anything yet.

Tell me:
What options do you see on the left menu?

For example, you might see:

Playground

Models

Deployments

Agents

Evaluations

or upload a screenshot of the left navigation.

From Now On
This is where the exciting part begins.

Once we create the deployment, we'll start writing manual code (no Copilot) to integrate:

Semantic Kernel
        ↓
Azure OpenAI
        ↓
EnterpriseAppAI
You'll understand every line of code because you'll also know exactly what Azure resource it's communicating with. That combination of cloud knowledge and application architecture is what distinguishes enterprise AI development from simply calling an API.


Today 3:31 PM
""Welcome, Soundararajan Thangavelu
Use a model
Manage your existing endpoints or deploy a new model.
View deployments

Build an agent
Create an AI agent by configuring instructions, tools, and knowledge without writing code.
Start building

Code an agent
Define and deploy an agent in code using Microsoft Agent Framework for full control and customization.
Start coding
API key
••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••

Project endpoint
https://enterprise-foundry.services.ai.azure.com/api/projects/enterprise-app

Azure OpenAI endpoint
https://enterprise-foundry.openai.azure.com/openai/v1

Model selection

Test in playground
Run prompts and see responses.

Explore models
Browse available models.

Compare models
Review benchmarks and capabilities. ""

🎉 Excellent! Congratulations.

You've successfully created your Azure AI Foundry resource. This is a major milestone in your EnterpriseAppAI journey.

Now we'll continue exactly as planned—one step at a time, with both theory and practical implementation.

🎯 Current Status
You have:

Azure Subscription                  ✅
Resource Group                      ✅
Azure AI Foundry Resource           ✅
Project                             ✅
Project Endpoint                    ✅
Azure OpenAI Endpoint               ✅
API Key                             ✅
Model Deployment                    ❌ Not Yet
EnterpriseAppAI Integration         ❌ Not Yet
Notice the only missing infrastructure piece is the Model Deployment.

Before We Deploy a Model
I want to teach one more concept because 99% of beginners confuse these terms.

Azure AI Foundry Architecture
                 Azure Subscription
                        │
                        ▼
                Resource Group
                        │
                        ▼
              Azure AI Foundry Resource
                        │
          ┌─────────────┴─────────────┐
          ▼                           ▼
     Project                    Azure OpenAI
          │                           │
          ▼                           ▼
   Prompt Flow                Model Deployment
          │                           │
          └─────────────┬─────────────┘
                        ▼
                 EnterpriseAppAI
Let's understand each component.

1. Azure AI Foundry Resource
You created:

enterprise-foundry
This is the container for your AI services.

Think of it like:

Visual Studio Solution
It contains multiple AI capabilities.

2. Project
You also created:

enterprise-app
A Project is your workspace.

Inside the project you'll later have:

Prompt playground

Model deployments

Agents

Connections

Evaluations

Think of it like:

Visual Studio Project
inside a solution.

3. Project Endpoint
You saw:

https://enterprise-foundry.services.ai.azure.com/api/projects/enterprise-app
What is this?
This endpoint is mainly used by:

Azure AI Foundry SDK

Agent Framework

Future AI Agents

We will NOT use this today.

4. Azure OpenAI Endpoint
You also saw:

https://enterprise-foundry.openai.azure.com/openai/v1
This is the important one.

Semantic Kernel will call this endpoint.

Later in our code:

ChatService

↓

Semantic Kernel

↓

Azure OpenAI Endpoint
This endpoint exposes the deployed models.

5. API Key
Today we'll use:

API Key
Later we'll replace it with:

Managed Identity

or

Azure Key Vault
because production systems shouldn't hardcode secrets.

❓What Is Still Missing?
You have the endpoint.

You have the API key.

But Azure still doesn't know which AI model you want to use.

That's why we need a deployment.

What Is a Deployment?
Imagine Microsoft offers:

GPT-4.1
GPT-4.1-mini
GPT-4o
GPT-4o-mini
o3
Embedding Models
Your application shouldn't reference those names directly.

Instead you create:

Deployment Name

enterprise-chat
which points to

GPT-4.1-mini
Later you can change it to:

GPT-4.1
without changing your code.

This is exactly the same principle as Dependency Injection.

Instead of depending on a concrete implementation, your application depends on an abstraction (the deployment name).

🎯 Practical Task 2
Now we're finally going to deploy our first model.

Step 1
Click:

Explore Models

(or View Deployments if it lets you deploy from there).

Step 2
Tell me:

Which chat models do you see?
Examples might include:

GPT-4.1

GPT-4.1-mini

GPT-4o

GPT-4o-mini

o3

o4-mini

⚠️ Don't deploy one yet.

We'll choose the best model for your learning project together.

🏆 Our Enterprise Strategy
We'll actually use two different models in this project:

Purpose    Recommended Model
Chat & Function Calling    GPT-4.1-mini
Embeddings (for RAG later)    text-embedding-3-large or text-embedding-3-small
Why two?

Because chat generation and vector embeddings solve different problems. We'll cover embeddings in detail when we build the Documents and RAG modules.

📘 Lesson Summary
Today you learned:

✅ Azure AI Foundry Resource

✅ Project

✅ Project Endpoint

✅ Azure OpenAI Endpoint

✅ API Key

✅ Why a Deployment is needed

This understanding is important because when we write our first Semantic Kernel integration, you'll know exactly which Azure endpoint it communicates with and why the deployment name is part of the configuration. That's the kind of understanding that helps in real enterprise projects and technical interviews.

Next step: Open Explore Models (or View Deployments) and tell me the list of available chat models. We'll choose the right one together before deploying it.


both model is available ""Purpose    Recommended Model
Chat & Function Calling    GPT-4.1-mini
Embeddings (for RAG later)    text-embedding-3-large or text-embedding-3-small""
what should I do next?

Deployment Name: enterprise-embedding
Model: text-embedding-3-small

Purpose:
This embedding model will be used later for the RAG (Retrieval-Augmented Generation) implementation in our EnterpriseAppAI project.

Responsibilities:

Convert documents into vector embeddings

Enable semantic search

Support Azure AI Search

Power the Knowledge Base

Retrieve relevant document chunks for RAG

Why text-embedding-3-small?

Lower cost than text-embedding-3-large

Fast performance

Excellent quality for learning and most enterprise scenarios

Recommended for our EnterpriseAppAI project

Deployment Configuration

Deployment Name: enterprise-embedding

Model: text-embedding-3-small

After this deployment succeeds, we'll proceed to integrating Semantic Kernel with your enterprise-chat deployment and then implement the first real AI-powered ChatService in your EnterpriseAppAI application.


I am changing this model ""gpt-5.6-sol"" instead of gpt-4.1-mini

That's a good question, and it's exactly the kind of architectural decision we should discuss before making changes.

Short Answer
I recommend that you do NOT use gpt-5.6-sol as the primary model for EnterpriseAppAI.

For our learning project, I recommend:

Chat & Function Calling: gpt-4.1-mini (or the latest stable general-purpose chat model available in your Azure subscription)

Embeddings: text-embedding-3-small

Why?
Our goal is not to use the newest model.

Our goal is to learn:

Semantic Kernel

Prompt Engineering

Function Calling

RAG

AI Agents

MCP

Enterprise Architecture

These concepts work across models.

Think of It Like .NET
Suppose you're learning ASP.NET Core.

Would you start with a preview version?

Usually not.

You'd use the stable version because:

Documentation matches.

Samples work.

Tutorials work.

Community support is better.

The same idea applies here.

What is gpt-5.6-sol?
Without checking your specific Azure deployment catalog, I can't confirm exactly what gpt-5.6-sol represents. It may be:

a preview model,

a specialized model,

or an Azure-specific deployment available in your subscription.

Before choosing it, we should verify its intended use, capabilities, and support for features like tool/function calling.

For EnterpriseAppAI
Our application will eventually perform tasks like:

Employee Search

↓

Leave Balance

↓

IT Tickets

↓

Document Search (RAG)

↓

AI Agents

↓

MCP
For these, we need a model that has strong support for:

Chat

Tool/Function Calling

Structured outputs

Stable SDK compatibility

Semantic Kernel compatibility

A mainstream chat model is the safer choice while learning.

My Recommendation
Option 1 (Recommended)
Deploy:

enterprise-chat
        ↓
GPT-4.1-mini
This keeps the course aligned with Microsoft documentation and Semantic Kernel samples.

Option 2
If your Azure subscription doesn't provide GPT-4.1-mini, then tell me exactly what chat models are available, and we'll choose the best supported one together.

If You Really Want to Use gpt-5.6-sol
I'm happy to adapt the course, but first I want to verify:

Is it a general-purpose chat model?

Does it support function calling/tools?

Is it supported by the current Semantic Kernel SDK?

That way we don't discover compatibility issues halfway through the project.

Please tell me one thing:
Why are you choosing gpt-5.6-sol?

Is gpt-4.1-mini unavailable?

Or do you simply want to use the newest model?

Your answer will help us choose the best path for the rest of the EnterpriseAppAI project.


it is deprecated gpt-4.1-mini

You're correct. As of now, gpt-4.1-mini is on the deprecation path in Azure AI Foundry, and Microsoft recommends migrating to newer GPT-5 family models before its retirement date. 

For Our EnterpriseAppAI Project
Since we're starting a new project in 2026, it makes sense to build on the newer generation rather than a model that's being phased out.

Recommended setup
Purpose    Model    Deployment Name
Chat, Function Calling, Agents    gpt-5.6-sol (or the latest stable GPT-5 chat model available in your subscription)    enterprise-chat
Embeddings    text-embedding-3-small    enterprise-embedding
Notice that we're keeping the deployment name as:

enterprise-chat
not

gpt-5.6-sol
Why keep enterprise-chat?
This is an important enterprise design principle.

Your code should never know the model name.

EnterpriseAppAI

↓

Semantic Kernel

↓

Deployment Name
enterprise-chat

↓

gpt-5.6-sol
Suppose next year Microsoft releases:

GPT-6
You can simply change the Azure deployment:

enterprise-chat

↓

GPT-6
Your application code remains exactly the same.

This is the same principle you've already learned with Dependency Injection:

IRepository → Repository

IChatService → ChatService

enterprise-chat → gpt-5.6-sol

The application depends on an abstraction (deployment name), not a concrete implementation (model).

One Small Adjustment for Our Course
Originally I planned to teach using GPT-4.1-mini because it matched the Microsoft samples available at that time.

We'll now update the course to use:

✅ GPT-5.6-sol (or the current stable GPT-5 model available in your Azure Foundry)

✅ Semantic Kernel (latest stable version)

✅ Azure AI Foundry SDKs where appropriate

✅ Latest Azure OpenAI APIs

That means you'll be learning with the current enterprise stack rather than older samples.

Next Step
Go ahead and create:

Chat Deployment
Model: gpt-5.6-sol

Deployment Name: enterprise-chat

Embedding Deployment
Model: text-embedding-3-small

Deployment Name: enterprise-embedding

Once both deployments show Succeeded, we'll move to Phase 5 – Semantic Kernel Integration.

There, we'll manually write every line of code (no Copilot) and I'll explain:

What a Kernel is.

Why Semantic Kernel exists.

Why we don't call Azure OpenAI directly.

How Dependency Injection works with the Kernel.

How ChatService will invoke your enterprise-chat deployment.

Why this architecture makes it easy to add plugins, function calling, RAG, agents, and MCP later.

That will be the first point where your existing Clean Architecture starts interacting with real AI in Azure.


I am going with gpt-5.4-mini

yes completed all now can we move to phase 5 

Absolutely! 🚀

This is the phase I've been waiting for because this is where your EnterpriseAppAI becomes an actual AI application.

From this point onward, I want to make one commitment:

I won't just tell you what to code—I will explain why we're doing it, what problem it solves, what alternatives exist, and why we're choosing this approach for EnterpriseAppAI.

This is exactly how senior engineers learn new technologies.

Phase 5 – Semantic Kernel Integration
Today's Goal
By the end of this phase, your architecture will become:

Employee
     │
     ▼
POST /api/chat
     │
     ▼
ChatController
     │
     ▼
IChatService
     │
     ▼
ChatService
     │
     ▼
Semantic Kernel
     │
     ▼
Azure OpenAI
     │
     ▼
enterprise-chat (gpt-5.4-mini)
     │
     ▼
AI Response
This is our first AI milestone.

Lesson 5.1 – What Problem Does Semantic Kernel Solve?
Let's start with a question.

Suppose there was no Semantic Kernel.

Your ChatService might look like this:

var client = new AzureOpenAIClient(...);

var response = await client.ChatCompletionsAsync(...);
That works.

So why did Microsoft build Semantic Kernel?

Without Semantic Kernel
Imagine that six months from now your application needs to:

Chat with users

Search employee database

Search HR policies (RAG)

Create IT tickets

Remember previous conversations

Call external APIs

Switch between Azure OpenAI and another LLM provider

Use multiple AI agents

Your ChatService would become something like:

ChatService

↓

Call Azure OpenAI

↓

If HR Question

↓

Search Database

↓

If Policy Question

↓

Search Azure AI Search

↓

If Ticket

↓

Call Ticket API

↓

Merge Results

↓

Call OpenAI Again
One class starts doing everything.

Problems
This violates several principles you've already learned.

❌ Single Responsibility Principle (SOLID)
ChatService becomes responsible for:

Prompt creation

AI communication

Tool execution

Memory

Plugin management

RAG

Function calling

Too many responsibilities.

❌ Difficult to Maintain
Every new feature means changing ChatService.

❌ Vendor Lock-in
If tomorrow you switch from Azure OpenAI to another provider, you have to change AI integration code everywhere.

Microsoft's Solution
Microsoft created Semantic Kernel.

Think of it as an AI orchestration framework.

It sits between your application and the LLM.

Application

↓

Semantic Kernel

↓

LLM
What Does "Orchestrator" Mean?
You answered this correctly yesterday.

Semantic Kernel decides what should happen next.

For example:

User:

"Create an IT ticket because my laptop isn't starting."

Semantic Kernel can:

Understand Intent

↓

Find Available Functions

↓

Call CreateTicket()

↓

Receive Result

↓

Generate Natural Language Response
Instead of you writing all that orchestration manually.

Real Enterprise Example
Imagine this question:

"How many leave days do I have?"

Semantic Kernel can orchestrate:

User Question

↓

LLM understands intent

↓

Call GetLeaveBalance()

↓

Receive Data

↓

Generate Response
Your application only provides the function.

Semantic Kernel manages the interaction with the model.

Another Example
User:

"Summarize our HR policy."

Semantic Kernel can:

User

↓

Search Vector Database

↓

Retrieve Top Documents

↓

Build Prompt

↓

Call LLM

↓

Return Summary
This is why it becomes so valuable once we implement RAG.

Why We're Choosing Semantic Kernel
There are other orchestration frameworks, such as:

Framework    Language    Good For
Semantic Kernel    .NET / C#    ✅ Best fit for our project
LangChain    Python    AI-first Python projects
LlamaIndex    Python    RAG-heavy applications
Microsoft Agent Framework    .NET    Multi-agent applications
Since your project is:

ASP.NET Core

Clean Architecture

CQRS

MediatR

Azure OpenAI

Semantic Kernel integrates naturally with the technologies you're already using.

How Semantic Kernel Fits Into EnterpriseAppAI
Eventually, it will orchestrate all of these:

                 Semantic Kernel
                        │
        ┌───────────────┼────────────────┐
        ▼               ▼                ▼
 Azure OpenAI     Employee Plugin    HR Plugin
        │               │                │
        └───────────────┼────────────────┘
                        ▼
                  IT Plugin
                        │
                        ▼
                  Azure AI Search
                        │
                        ▼
                    SQL Server
Notice that Semantic Kernel doesn't replace your business logic.

Your existing services, repositories, CQRS handlers, and APIs remain exactly as they are.

Semantic Kernel simply coordinates how the AI interacts with them.

Our Development Strategy
We'll build this gradually.

Step 1
Semantic Kernel

↓

Azure OpenAI

↓

Chat

Step 2
Semantic Kernel

↓

Plugins

↓

Employee Module

Step 3
Semantic Kernel

↓

Function Calling

↓

HR Module

Step 4
Semantic Kernel

↓

Azure AI Search

↓

RAG

Step 5
Semantic Kernel

↓

Agents

↓

Enterprise Copilot

🎯 Today's Practical Task
We are not writing code yet.

First, I want you to understand one more concept before installing any NuGet packages.

Lesson 5.2
What is a Kernel?

We'll answer:

What is a Kernel?

Why is it called a Kernel?

What does it actually contain?

Why do we register it with Dependency Injection?

How does it communicate with Azure OpenAI?

Why don't we inject AzureOpenAIClient directly?

Once you understand that, the code will feel very natural instead of looking like magic.

This lesson is the foundation for everything that follows: plugins, function calling, RAG, agents, and MCP.


yes

Excellent. This is probably the most important concept in Semantic Kernel. Once you understand this, the rest of the AI integration will make much more sense.

Lesson 5.2 – What is a Kernel?
Let's start with something you're already familiar with.

Question
What is an ASP.NET Core application?

You might say:

Program.cs

↓

Dependency Injection

↓

Middleware

↓

Controllers

↓

Services

↓

Repositories
But who coordinates everything?

ASP.NET Core Runtime.

When an HTTP request comes in, the runtime decides:

Which middleware runs first?

Which controller should handle the request?

Which service should be injected?

You don't write that orchestration yourself.

Another Example
Think about Entity Framework Core.

You don't write:

Open Connection

↓

Create Transaction

↓

Convert Object to SQL

↓

Execute SQL

↓

Map Result

↓

Close Connection
Instead, you write:

await dbContext.Employees.ToListAsync();
EF Core orchestrates all the lower-level work.

Semantic Kernel is Similar
Semantic Kernel is an orchestration framework for AI.

Instead of orchestrating HTTP requests or database operations, it orchestrates AI interactions.

Application

↓

Semantic Kernel

↓

LLM

↓

Plugins

↓

Memory

↓

Prompt

↓

Functions

↓

Response
Why Is It Called a "Kernel"?
Think of an operating system.

Windows

↓

Kernel

↓

CPU

↓

Memory

↓

Disk

↓

Drivers
The OS kernel coordinates all hardware resources.

Similarly:

Semantic Kernel

↓

AI Model

↓

Plugins

↓

Memory

↓

Prompts

↓

Function Calling
It coordinates all AI-related resources.

That's why Microsoft chose the name Kernel.

What Does a Kernel Contain?
Conceptually, a Kernel acts like a container for AI capabilities.

Kernel

├── AI Service
├── Prompt Execution
├── Plugins
├── Functions
├── Memory
└── Settings
Later in our project, it will manage all of these for us.

Why Not Inject AzureOpenAIClient Directly?
Let's compare.

Option 1 – Direct SDK
ChatService

↓

AzureOpenAIClient

↓

GPT
This is fine for a simple chatbot.

But what happens when you want to:

Call Employee APIs

Execute HR functions

Search Azure AI Search

Use memory

Add plugins

Introduce agents

You end up building orchestration yourself.

Option 2 – Semantic Kernel
ChatService

↓

Kernel

↓

Azure OpenAI

↓

Plugins

↓

Memory

↓

Functions

↓

Response
Now the Kernel becomes the AI orchestrator.

Real Enterprise Example
Suppose a user asks:

"My laptop is broken. Create an IT ticket."

Without Semantic Kernel:

ChatService

↓

Call GPT

↓

Detect Intent

↓

Call Ticket Service

↓

Generate Response

↓

Return Result
You write all the orchestration.

With Semantic Kernel:

ChatService

↓

Kernel

↓

LLM

↓

Discovers CreateTicket()

↓

Calls Function

↓

Formats Answer

↓

Returns Response
Much cleaner.

Where Does the Kernel Live?
In our application:

ChatController

↓

IChatService

↓

ChatService

↓

Kernel

↓

Azure OpenAI
Notice something important.

The rest of your application doesn't know about Azure OpenAI.

It only knows about IChatService.

That's because we keep AI-specific logic inside the AI layer.

This aligns perfectly with the Clean Architecture you've already built.

What Will We Register in DI?
Soon we'll register something like this (conceptually):

Dependency Injection

↓

Kernel

↓

Azure OpenAI Chat Service

↓

enterprise-chat Deployment
Then, whenever ChatService needs AI capabilities, it receives the configured Kernel from DI instead of constructing everything manually.

How This Scales
Today:

Kernel

↓

Azure OpenAI
Next week:

Kernel

↓

Azure OpenAI

↓

Employee Plugin
Then:

Kernel

↓

Azure OpenAI

↓

Employee Plugin

↓

HR Plugin
Later:

Kernel

↓

Azure OpenAI

↓

Employee Plugin

↓

HR Plugin

↓

IT Plugin

↓

Azure AI Search

↓

Memory
And eventually:

Kernel

↓

Multiple Agents

↓

MCP

↓

Enterprise Copilot
See why we don't start with the Azure OpenAI SDK directly? We'd eventually have to build all of this orchestration ourselves.

🎓 Interview Perspective
If an interviewer asks:

"Why did you use Semantic Kernel instead of calling Azure OpenAI directly?"

A strong answer is:

"Our application started as a simple chat experience, but we needed an orchestration layer to support plugins, function calling, conversation memory, RAG, and AI agents without tightly coupling those concerns to the chat service. Semantic Kernel provides that orchestration while integrating naturally with our .NET dependency injection and Clean Architecture."

✅ Check Your Understanding
Before we write any code, answer these three questions in your own words:

What is a Kernel?

Why don't we inject AzureOpenAIClient directly into ChatService?

What responsibilities will the Kernel eventually have in our EnterpriseAppAI application?

Don't worry about using perfect terminology. I want to see your understanding, just like we did with RAG and Semantic Kernel earlier. Once you're comfortable with these concepts, we'll install our first Semantic Kernel package and write the integration together.


can we go practical for integrating semantic kernel for our app

Absolutely! 😊

And I think this is the right time.

You've already understood the theory:

✅ Why LLM can't access databases

✅ Why RAG is needed

✅ Why Semantic Kernel exists

✅ What a Kernel is

✅ Why we use an orchestration layer

Now let's make EnterpriseAppAI AI-powered.

🎯 Phase 5 - Practical Implementation
We'll integrate Semantic Kernel step by step.

Important: We will not use Copilot. We'll write and understand every line.

Final Architecture
ChatController
      │
      ▼
IChatService
      │
      ▼
ChatService
      │
      ▼
Kernel
      │
      ▼
Azure OpenAI Chat Completion Service
      │
      ▼
enterprise-chat
(gpt-5.4-mini)
Practical Roadmap
We'll complete this in small milestones.

Milestone 1 - Install Packages
Learn:

What packages are required?

Why each package?

Milestone 2 - Configuration
Learn:

Endpoint

API Key

Deployment Name

Options Pattern

Milestone 3 - Dependency Injection
Learn:

Register Kernel

Register Chat Completion Service

Milestone 4 - ChatService
Replace placeholder implementation.

Milestone 5
Call API

POST /api/chat

↓

Real Azure OpenAI Response
✅ Milestone 1 - Install Packages
Why not install 15 packages?
Many YouTube tutorials install everything.

We won't.

We'll install only what we need.

Package 1
Install in

EnterpriseAppAI.Infrastructure
Microsoft.SemanticKernel
Why?
This is the core orchestration framework.

Without this there is no Kernel.

Package 2
Microsoft.SemanticKernel.Connectors.AzureOpenAI
Why?
Semantic Kernel itself doesn't know how to communicate with Azure OpenAI.

This connector teaches Semantic Kernel how to call Azure OpenAI.

Think of it like EF Core:

Microsoft.EntityFrameworkCore

+

Microsoft.EntityFrameworkCore.SqlServer
Exactly the same idea.

Why Infrastructure?
Remember our Clean Architecture?

Application
contains

IChatService
Application should not know:

Azure

OpenAI

Semantic Kernel

API Keys

Those are infrastructure concerns.

Therefore:

Infrastructure

↓

Semantic Kernel

↓

Azure OpenAI
Expected Project Structure
EnterpriseAppAI.Infrastructure

│
├── AI
│     ├── ChatService.cs
│     ├── DependencyInjection.cs
│     └── (future plugins)
│
├── Persistence
├── Authentication
└── ...
❓Why is ChatService in Infrastructure?
Your interface:

IChatService
belongs to Application.

Implementation:

ChatService
talks to Azure OpenAI.

Azure is Infrastructure.

This follows the Dependency Inversion Principle you've already applied with repositories.

📌 Your First Task
Install these two NuGet packages in EnterpriseAppAI.Infrastructure:

Microsoft.SemanticKernel
Microsoft.SemanticKernel.Connectors.AzureOpenAI
Don't install any preview packages unless there's no stable version available. Use the latest stable release compatible with your project and SDK.

⛔ Stop After Installing
Don't write any code yet.

Tell me:

Which versions were installed?

Did the solution build successfully?

What We'll Do Next
Once the packages are installed, we'll continue with Milestone 2:

We'll create a strongly typed configuration class:

AzureOpenAIOptions
Then I'll explain:

Why we use the Options Pattern

Why we don't read appsettings.json directly

Why this design makes testing and future changes easier

We'll build the integration exactly as it would be done in a real enterprise .NET application.


this is my current structure ""

EnterpriseAppAl.Infrastructure



Analyzers

Frameworks

Packages

Microsoft.EntityFrameworkCore.Design (10.0.10)

Microsoft.EntityFrameworkCore.SqlServer (10.0.10)

Microsoft.EntityFrameworkCore.Tools (10.0.10)

Microsoft.Extensions.Configuration.Binder (10.0.10)

Microsoft.SemanticKernel (1.78.0)

Microsoft.SemanticKernel.Connectors.AzureOpenAl (1.78.0)
System.IdentityModel.Tokens.Jwt (8.19.2)

Projects

Al

Services

>  C# ChatService.cs

v  Dependencylnjection

C# Dependencylnjection.cs

>  Identity

Persistence

EnterpriseAppAl.Shared



A CH""

Excellent! 👍 You're doing exactly what a senior developer would do—checking the project structure before writing code.

Current Status ✅
You have installed:

Package    Version    Status
Microsoft.SemanticKernel    1.78.0    ✅
Microsoft.SemanticKernel.Connectors.AzureOpenAI    1.78.0    ✅
These versions are perfectly fine for our project.

Let's Review Your Structure
Infrastructure
│
├── AI
│     └── ChatService.cs
│
├── DependencyInjection
│     └── DependencyInjection.cs
│
├── Identity
│
├── Persistence
│
└── Services
This is a good structure. 👍

I would keep it with one small improvement as the AI part grows.

Infrastructure
│
├── AI
│   ├── ChatService.cs
│   ├── Options
│   ├── Plugins        (Later)
│   ├── Prompts        (Later)
│   └── Memory         (Later)
│
├── DependencyInjection
├── Identity
├── Persistence
└── Services
Notice I'm not asking you to create everything now.

We'll create folders only when we need them.

🎯 Next Practical Task
Now we're going to create our first AI configuration.

Why Do We Need Configuration?
Imagine writing:

new AzureOpenAIChatCompletionService(
    "enterprise-chat",
    "https://enterprise-foundry.openai.azure.com/",
    "xxxxxxxxxxxxxxxxxxxxxxxx");
inside ChatService.

❌ This is a bad practice.

Why?

API Key changes

Endpoint changes

Deployment changes

Different environments (Dev/Test/Prod)

You'd have to modify and redeploy code.

Enterprise Way
Instead:

appsettings.json

↓

Options Pattern

↓

Dependency Injection

↓

ChatService
Exactly the same pattern you've already used for JWT configuration.

Task 1 – Create Options Folder
Inside

Infrastructure
    └── AI
Create

Options
Task 2 – Create AzureOpenAIOptions.cs
Infrastructure
└── AI
    └── Options
        └── AzureOpenAIOptions.cs
What Should It Contain?
Before I give you the code, I want you to think.

Our application needs three pieces of information:

Azure Endpoint

Deployment Name

API Key
Question:

Where should these values live?

Not in code.

They should come from

appsettings.json

↓

AzureOpenAIOptions

↓

Dependency Injection
Why the Options Pattern?
This is exactly the same concept as:

JwtOptions

EmailOptions

AzureOpenAIOptions
All infrastructure configuration is represented by strongly typed option classes.

What We'll Build
appsettings.json

↓

AzureOpenAIOptions

↓

IOptions<AzureOpenAIOptions>

↓

Dependency Injection

↓

Kernel

↓

ChatService
🧠 Think Before Coding
Before I provide the class, I want you to answer one question.

What properties do you think AzureOpenAIOptions should have?
Don't worry about exact names.

Think conceptually.

For example:

Endpoint?

API Key?

Deployment Name?

Anything else?

Reply with your list.

This exercise is important because in enterprise development, we first identify what configuration the application needs, then we design the options class. Once you answer, we'll write the class together and bind it using the .NET Options Pattern.


can create json object which is pasting to appsetting.json file and share here?

I created AzureOpenAIOptions class and pasted properities which you gave

Excellent! 🎉

You've now completed the first piece of AI infrastructure.

So far we've built:

appsettings.json
        │
        ▼
AzureOpenAIOptions
Now we need to bind that configuration and create the Semantic Kernel.

This is the most important coding step in Phase 5.

Task 3 – Register Semantic Kernel
Concept
Right now you only have a C# class.

AzureOpenAIOptions
But it's empty.

.NET doesn't automatically populate it.

We need to tell Dependency Injection:

"Read the AzureOpenAI section from appsettings.json and populate this class."

This is called Configuration Binding.

After binding
The architecture becomes:

appsettings.json

        │

Configuration Binder

        │

AzureOpenAIOptions

        │

Dependency Injection

        │

ChatService
Why are we doing this?
Without DI you'd have to write:

var endpoint = builder.Configuration["AzureOpenAI:Endpoint"];
inside every service.

Imagine doing that in:

ChatService

DocumentService

EmbeddingService

HRService

AgentService

That becomes repetitive and error-prone.

Instead, we bind once at startup.

Next Implementation
Open:

Infrastructure
    └── DependencyInjection
            └── DependencyInjection.cs
You already have methods like:

AddInfrastructure(...)
We're going to extend that.

Step 1 – Bind the Options
Add:

services
    .AddOptions<AzureOpenAIOptions>()
    .Bind(configuration.GetSection(AzureOpenAIOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();
❓Wait… Why ValidateDataAnnotations()?
Good question.

Right now your class doesn't have any validation attributes.

For example:

[Required]
public required string ApiKey { get; init; }
We haven't added those yet.

So don't use ValidateDataAnnotations() just yet.

Instead, use:

services.Configure<AzureOpenAIOptions>(
    configuration.GetSection(AzureOpenAIOptions.SectionName));
This is simpler and matches our current class.

Later, when we discuss configuration validation, we'll upgrade it.

Step 2 – Don't Register the Kernel Yet
This is intentional.

Many tutorials immediately do:

builder.Services.AddKernel();
without explaining what happens.

I don't want to do that.

Before we register the Kernel, I want you to understand:

What AddKernel() actually creates

Why it returns an IKernelBuilder

Why we add Azure OpenAI to the Kernel

How the Kernel is resolved from DI

That understanding will make the code much easier to follow.

Current Progress
✔ Azure AI Foundry
✔ GPT Deployment
✔ Embedding Deployment
✔ Packages
✔ appsettings.json
✔ AzureOpenAIOptions

NOW

⬇

Configuration Binding

NEXT

⬇

Kernel Registration

NEXT

⬇

Azure OpenAI Registration

NEXT

⬇

ChatService
🎯 Your Task
In DependencyInjection.cs:

Add the using for your AzureOpenAIOptions namespace.

Add:

services.Configure<AzureOpenAIOptions>(
    configuration.GetSection(AzureOpenAIOptions.SectionName));
Build the solution.

One Small Suggestion
From now on, I recommend we avoid copying large chunks of code from me.

Instead, I'll explain the concept first, then give you the relevant snippet and explain why each line exists. That way you'll be able to write and explain this code confidently in interviews, not just make it compile.

Once you've added the configuration binding and the build succeeds, we'll move to Kernel registration, where you'll finally see how Semantic Kernel integrates with your existing Clean Architecture.


I added this code ""builder.Services
    .AddOptions<AzureOpenAIOptions>()
    .Bind(builder.Configuration.GetSection(AzureOpenAIOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart(); "" into program.cs

That's good, but I would make one architectural improvement.

Remember our Clean Architecture rule:

Program.cs should be as thin as possible.

Earlier you already moved:

✅ EF Core registration

✅ JWT registration

✅ Repository registration

✅ Unit of Work registration

✅ MediatR registration

into extension methods.

Let's do the same for AI.

Why shouldn't this stay in Program.cs?
Right now you have:

builder.Services
    .AddOptions<AzureOpenAIOptions>()
    .Bind(builder.Configuration.GetSection(AzureOpenAIOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();
Today it's only 4 lines.

But soon you'll add:

Semantic Kernel

Azure OpenAI Chat Service

Embedding Service

Plugins

Memory

Filters

Prompt Templates

Then Program.cs becomes:

Program.cs

↓

Authentication

↓

Authorization

↓

Database

↓

JWT

↓

Logging

↓

AI

↓

Kernel

↓

Plugins

↓

Memory

↓

OpenAPI

↓

...
Eventually it grows to hundreds of lines.

Enterprise Approach
Move all AI-related registrations into Infrastructure.

Example:

Infrastructure
│
├── AI
│
├── DependencyInjection
│     └── DependencyInjection.cs
Then create an extension method such as:

services.AddAI(configuration);
or

services.AddInfrastructure(configuration);
Internally it will register:

AzureOpenAIOptions

Semantic Kernel

Azure OpenAI Chat Completion

ChatService

Future AI services

Then Program.cs stays clean:

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);
That's it.

About ValidateDataAnnotations()
This line is fine only if your AzureOpenAIOptions class has validation attributes like:

using System.ComponentModel.DataAnnotations;

public sealed class AzureOpenAIOptions
{
    public const string SectionName = "AzureOpenAI";

    [Required]
    public required string Endpoint { get; init; }

    [Required]
    public required string ApiKey { get; init; }

    [Required]
    public required string ChatDeploymentName { get; init; }

    [Required]
    public required string EmbeddingDeploymentName { get; init; }
}
If you haven't added [Required] attributes yet, then ValidateDataAnnotations() doesn't actually validate anything.

What I Recommend
✅ Move this registration from Program.cs to Infrastructure.DependencyInjection.

✅ Add [Required] attributes to AzureOpenAIOptions.

✅ Keep Program.cs minimal.

🎯 Next Major Step
Now comes the exciting part.

We'll register the Semantic Kernel itself.

You'll learn:

What AddKernel() does internally.

What an IKernelBuilder is.

Why we add the Azure OpenAI Chat Completion service to the Kernel.

How the Kernel object is injected into ChatService.

This is where your application will be able to send its first real request to Azure OpenAI.


I did this changes ""  // Azure OpenAI options: bind configuration and validate on start (manual bind + DataAnnotations validation)
  var azureSection = configuration.GetSection(EnterpriseAppAI.Infrastructure.AI.Options.AzureOpenAIOptions.SectionName);
  var azureOptions = azureSection.Get<EnterpriseAppAI.Infrastructure.AI.Options.AzureOpenAIOptions>();
  if (azureOptions == null)
  {
      throw new InvalidOperationException($"Configuration section '{EnterpriseAppAI.Infrastructure.AI.Options.AzureOpenAIOptions.SectionName}' is missing.");
  }

  // Validate DataAnnotations (if any are present on the options class)
  var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(azureOptions);
  var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
  if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(azureOptions, validationContext, validationResults, validateAllProperties: true))
  {
      var errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
      throw new InvalidOperationException($"AzureOpenAIOptions validation failed: {errors}");
  }"" in infrastructure layer

Excellent work. 👍 You're thinking about validation, which is good. However, for a modern .NET application, I would simplify this.

Is your code correct?
Yes. It will work.

Your code:

✅ Reads the configuration.

✅ Checks if the section exists.

✅ Validates DataAnnotations.

✅ Throws during startup if the configuration is invalid.

That's good behavior.

But is it the recommended .NET approach?
I would say not anymore.

The .NET team already provides built-in support for this.

Instead of manually writing:

var azureSection = configuration.GetSection(...);

var azureOptions = azureSection.Get<...>();

Validator.TryValidateObject(...);
we can let the framework handle it.

Enterprise Approach
In AddInfrastructure():

services
    .AddOptions<AzureOpenAIOptions>()
    .Bind(configuration.GetSection(AzureOpenAIOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();
Then decorate your options class:

using System.ComponentModel.DataAnnotations;

public sealed class AzureOpenAIOptions
{
    public const string SectionName = "AzureOpenAI";

    [Required]
    [Url]
    public required string Endpoint { get; init; }

    [Required]
    public required string ApiKey { get; init; }

    [Required]
    public required string ChatDeploymentName { get; init; }

    [Required]
    public required string EmbeddingDeploymentName { get; init; }
}
Why is this better?
Less code to maintain.

Consistent with the .NET ecosystem.

Easy to extend.

Automatic validation during startup.

Works naturally with IOptions<T>.

As you learn more .NET, you'll notice a recurring theme: prefer the framework's built-in capabilities over custom infrastructure unless you have a specific need.

My Recommendation
I'd replace the manual validation with the built-in Options Pattern validation. It'll keep your Infrastructure layer cleaner and match what you'll see in most modern ASP.NET Core projects.

✅ Now Let's Move to the Most Exciting Part
We've completed:

✅ Azure Resource
✅ Azure OpenAI Model
✅ AzureOpenAIOptions
✅ Configuration Binding
The next step is where your application actually becomes AI-enabled.

Task 4 – Register Semantic Kernel
This is the milestone where we'll answer:

What does AddKernel() actually do?

What is IKernelBuilder?

Why does the Kernel need an Azure OpenAI Chat Completion service?

How does the Kernel become available through Dependency Injection?

After this step, your architecture will look like:

ChatController
        │
        ▼
IChatService
        │
        ▼
ChatService
        │
        ▼
Kernel
        │
        ▼
Azure OpenAI Chat Completion Service
        │
        ▼
enterprise-chat (gpt-5.4-mini)
This is the point where you'll be only one small step away from sending your first real prompt to Azure OpenAI from your EnterpriseAppAI application.

I recommend we spend time understanding AddKernel() rather than just pasting code, because it becomes the foundation for plugins, function calling, RAG, agents, and MCP later in the project.


can we next step of practical

Yes! Now we reach the most important practical step in Phase 5.

🚀 Phase 5 - Task 4
Register Semantic Kernel
Before writing code, I want to explain what we're creating.

Today
Your DI container contains services like:

IRepository
↓

Repository

↓

DbContext
For AI, we're going to register something similar:

Kernel
    │
    ▼
Azure OpenAI Chat Completion Service
    │
    ▼
enterprise-chat
When ChatService needs AI, it won't create anything manually. It will receive a configured Kernel from Dependency Injection.

Step 1 - Register the Kernel
Open your Infrastructure DependencyInjection.cs.

Inside your AddInfrastructure() method, add:

services.AddKernel();
❓What does AddKernel() do?
It does not call Azure OpenAI.

It does not send prompts.

It simply registers the Semantic Kernel infrastructure in the DI container.

Think of it like:

services.AddDbContext<ApplicationDbContext>();
This registers EF Core, but it doesn't execute any SQL.

Similarly:

services.AddKernel();
registers the Kernel so that other services can use it.

Step 2 - Configure Azure OpenAI
Next, instead of only calling AddKernel(), we'll configure it.

Replace it with:

var kernelBuilder = services.AddKernel();
Notice something interesting.

AddKernel() returns an object.

That object is:

IKernelBuilder
What is IKernelBuilder?
Think of it like IServiceCollection.

You don't use IServiceCollection to execute code.

You use it to configure services.

Likewise:

IKernelBuilder

↓

Add Chat Completion

↓

Add Plugins

↓

Add Memory

↓

Add Filters
It is a builder used to configure everything the Kernel needs before the application starts.

Your First Practical Task
Add this:

var kernelBuilder = services.AddKernel();
Don't add anything else yet.

Build the solution.

What We'll Do Next
Once that builds successfully, we'll configure the Kernel to use your Azure OpenAI deployment by adding the Azure OpenAI Chat Completion service to kernelBuilder.

That is the exact point where your enterprise-chat deployment becomes available to the Kernel, and your application will be ready to send its first AI prompt.

We'll take that step together so you understand every parameter instead of just copying code.


services.AddKernel(); AddKernel method is not available so it is give error

Excellent observation! 👏 This is exactly the kind of issue I want you to ask about instead of trying random fixes.

The fact that services.AddKernel() is missing tells us one of three things:

The required namespace is missing.

The package version has changed its API.

The extension method has moved in Semantic Kernel 1.78.0.

Since you're using Microsoft.SemanticKernel 1.78.0, the API has evolved from many older tutorials.

Let's diagnose it properly
Please answer these two questions:

1. What using statements do you have at the top of DependencyInjection.cs?
2. More importantly, what is the exact error message?
For example, is it:

'IServiceCollection' does not contain a definition for 'AddKernel'

or something else?

Don't try to work around it
Please don't install additional packages or change versions yet.

One thing I've committed to during this learning journey is that we're going to use the current stable APIs, not copy code from older blog posts that targeted previous Semantic Kernel versions.

After we identify the API change
We'll adapt our implementation to Semantic Kernel 1.78.0 and I'll explain:

Why the API changed.

What replaced AddKernel() (if it has).

Why Microsoft redesigned it.

How it affects Dependency Injection.

That way you'll learn the modern approach rather than memorizing outdated samples.

Please share:

The exact compiler error.

The using statements from the top of DependencyInjection.cs.

We'll fix it together and continue with the practical implementation.


AddKernel() is not available 

Great catch. Let's debug this like a senior developer instead of guessing.

AddKernel() does exist in Semantic Kernel and returns an IKernelBuilder, but it's provided as an extension method on IServiceCollection. 

If Visual Studio says it doesn't exist, it's usually because the extension method's namespace isn't imported, not because the package is missing.

Step 1 - Add these using statements
At the top of your DependencyInjection.cs, ensure you have:

using Microsoft.SemanticKernel;
using Microsoft.Extensions.DependencyInjection;
Build again.

Step 2 - If it still doesn't work
I want to verify one thing before we proceed.

Please share your Infrastructure.csproj (or EnterpriseAppAI.Infrastructure.csproj) and especially the package references.

It should contain something like:

<PackageReference Include="Microsoft.SemanticKernel" Version="1.78.0" />
<PackageReference Include="Microsoft.SemanticKernel.Connectors.AzureOpenAI" Version="1.78.0" />
Step 3 - Don't continue yet
Don't use Kernel.CreateBuilder().

Although it's valid, I intentionally don't want to use it because our application is ASP.NET Core with Dependency Injection. The DI-based approach (services.AddKernel()) is the architecture I want you to learn for EnterpriseAppAI. Microsoft also recommends integrating the Kernel with your application's DI container for ASP.NET Core applications rather than creating a standalone kernel. 

Please send me:
The contents of EnterpriseAppAI.Infrastructure.csproj.

The first 15–20 lines of DependencyInjection.cs (including all using statements).

Once I see those, we'll identify the exact cause and continue with the Semantic Kernel integration. This is a good learning moment because understanding why an extension method isn't found is a useful .NET debugging skill.


