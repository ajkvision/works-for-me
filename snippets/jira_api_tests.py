from atlassian import Jira
from atlassian import Confluence

jira_instance = "https://my.atlassian.net"

jira = Jira(jira_instance, username="my@email.com", password="API-TOKEN-HERE", cloud=True)

test_jira_key = 'TST-1'
jira_issue = jira.issue(test_jira_key)

#show basic issue info
summary = jira_issue.fields.summary    
reporter = jira_issue.fields.reporter


# attaching test reports - PoC
jira.add_attachment(issue=test_jira_key, attachment='/some/path/report_resulst.pdf')


confluence = Confluence(
    url='https://your-domain.atlassian.net',
    username=atlassian_username,
    password=atlassian_api_token,
    cloud=True)

print(jira.api_version)
