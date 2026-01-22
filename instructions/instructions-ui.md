# 1. Technologies to use

Use nextJS and bootstrap 5 if needed, do NOT use nodejs or expressjs

# 2. UI References

Check the folder "references" for the folder dashio. It contains a complete bootstrap template. Use this as the main reference when creating the UI

Inside the dashio folder there is a file "claude.md" read the file to understand how to implement the templated. Reply back to the user "I've reviewed the dashio folder and read the claude.md file" . Ask the user any clarifying questions needed.

create the nextjs app as protos-ui

# 3. UI Elements

## 3.1 Login screen 

Use the login.html template from dashio/src/pages folder 

## 3.2 Main dashboard page

This is available to the user once logged in. Use the template called dashboard-projects.html from the dashio/src/pages folder 

The goal of this page is to show:
- on top a navbar with the logo, and at the right user options including logout button
- on the left side a menu with available functionalities:
    - create a project
    - create a test plan
    - create test cases
    - assign test cases
    - manager projects
    - manage test plans
    - manage users

    Ensure this page is properly connected to the backend api


