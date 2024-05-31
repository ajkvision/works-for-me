from atlassian import Jira
from atlassian import Confluence

jira_instance = "https://my.atlassian.net"

jira = Jira(jira_instance, username="my@email.com", password="API-TOKEN-HERE", cloud=True)

confluence = Confluence(
    url='https://your-domain.atlassian.net',
    username=atlassian_username,
    password=atlassian_api_token,
    cloud=True)

print(jira.api_version)
