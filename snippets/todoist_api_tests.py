from todoist_api_python.api import TodoistAPI

api = TodoistAPI("")

try:
    projects = api.get_projects()
    print(projects)
except Exception as error:
    print(error)
