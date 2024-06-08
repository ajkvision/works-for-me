from todoist_api_python.api import TodoistAPI

api = TodoistAPI("")

#create prject - for testc case execution 

try:
    project = api.add_project(name="Test Execution - Smoke test 01")
    print(project)
except Exception as error:
    print(error)

try:
    projects = api.get_projects()
    print(projects)
except Exception as error:
    print(error)
