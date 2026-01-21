# 1. Project purpose

Project is to rewrite the testink application from php to c# using .net framework 9

# 2. Approach

Work is divided in phases:
1. Backend generation
2. Frontend generation

Phase 2 will start only after completion of phase 1. A specific prompt "start phase 2" will mark that

Backend generation
1. Use dotnet core web api for the backend APIs
2. Storage will be a mariadb database but do NOT use that right now, mockup and APIs or data needed
3. Models are provided in the folder "References" as Models.txt
4. Testlink original source code is provided in the folder "Testlink"

Workflow

1. Read the file instructions-general.md and reply back to the user with the text "I have read the general instructions"
2. Begin work on Phase 1 - backend generation only after you have reviewed the folder "Testlink" to look at the source codebase
3. Prompt the user at any point should you have a question