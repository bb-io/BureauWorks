# Blackbird.io Bureau Works

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

Bureau Works is cutting edge translation software that helps its users translate at greater speeds and with an increased sense of authorship.

## Before setting up

Before you can connect you need to make sure that:

- You have a Bureau Works account on the instance you want to connect to.
- In Bureau Works go to Profile > Security and click _Generate_ in API Token section.
- Copy _Access key_ and _Secret_ for future

## Connecting

1. Navigate to apps and search for Bureau Works.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My Bureau Works connection'.
4. Fill in the_Access key_ and _Secret_ that you copied from Bureau Works.
5. Click _Authorize connection_.

![connectionsetup](image/README/connectionsetup.png)

## Setting up events

1. Create a bird with event trigger from Bureau Works app and publish it
2. Copy "Webhook URL" from event trigger of published bird
3. Got to the [Webhooks page](https://app.bwx.io/settings/account-settings/webhooks) on Bureau Works.
4. Paste "Webhook URL" to the url field and leave "Secret" field empty
5. Select webhook type the same you chose in step 1 in Blackbird (For example if you selected "On project status changed" in Blackbird - select "Project status changed" webhook type in Bureau Works).
6. Click "Save webhook"

![eventsetup0](image/README/eventsetup0.png)

![eventsetup1](image/README/eventsetup1.png)

## Actions

### Project

- **Create project**
- **Change project status**
- **Download translated files**
- **Get project**
- **Search projects**
- **Upload file to project**

### Glossary

- **Create glossary**
- **Export glossary**
- **Import glossary**

## Events

- **On projects created**. Polling event that periodically checks for new projects. If a new projects are found, it will return the new projects.
- **On projects status changed**. Polling event that periodically checks for projects with updated statuses. It will return projects that match your criteria.
- **On project status changed**. Polling event that periodically checks for project status changes. If a project status changes, it will return the project with the new status.
- **On task status changed**. Polling event that periodically checks for new tasks. If a new tasks are found, it will return the new tasks.
- **On users created**. Polling event that periodically checks for new users. If a new users are found, it will return the new users.

## Missing features

Not all API endpoints are covered, let us know if you are missing features or if you see other improvements!

## Feedback

Feedback to our implementation of Bureau Works is always very welcome. Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
