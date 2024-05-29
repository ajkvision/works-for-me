from atlassian import Jira

jira_instance = "https://my.atlassian.net"

jira = Jira(jira_instance, username="my@email.com", password="API-TOKEN-HERE", cloud=True)

print(jira.api_version)
