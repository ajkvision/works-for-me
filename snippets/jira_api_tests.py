from atlassian import Jira
from atlassian import Confluence

jira_instance = "https://my.atlassian.net"

jira = Jira(jira_instance, username="my@email.com", password="API-TOKEN-HERE", cloud=True)

print(jira.api_version)

test_jira_key = 'TST-1'
jira_issue = jira.issue(test_jira_key)

#show basic issue info
summary = jira_issue.fields.summary    
reporter = jira_issue.fields.reporter
worklogs = jira_issue.fields.worklogs


# attaching test reports - PoC
jira.add_attachment(issue=test_jira_key, attachment='/some/path/report_resulst.pdf')

# adding a cooment about repost resulst 

comment = jira.add_comment(test_jira_key, 'Test results: FAIL. See more details in attachments') 


confluence = Confluence(
    url='https://your-domain.atlassian.net',
    username=atlassian_username,
    password=atlassian_api_token,
    cloud=True)

# Create page from scratch - 
title = 'test report'
confluence.create_page(space, title, body, parent_id=None, type='page', representation='storage', editor='v2', full_width=False)
# Export page example 
confluence.export_page(page_id)


