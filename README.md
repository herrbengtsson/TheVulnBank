# TheVulnBank
A deliberately vulnerable webapplication (resembling an online bank), for use in security awereness training.

**Do not install this application on you system if you don't know what you're doing!**

# Installation
TBD

# Configuration
TBD, but should be able to set level of security

# Vulnerabilities
We aim at have an all-star OWASP top 10 application :)

## A1 Injection
### Testing for SQL Injection (OTG-INPVAL-005)
Login??

## A2 Broken Authentication and Session Management
### Testing for Account Enumeration and Guessable User Account (OTG-IDENT-004)
No clipping level on login page, states if it's username or password that doesnt match
### Testing for Session Fixation (OTG-SESS-003)
If possible in .NET??
### Testing for Cookies attributes (OTG-SESS-002)
No HttpOnly or Secure :)

## A3 Cross-Site Scripting (XSS)
### Testing for Reflected Cross Site Scripting (OTG-INPVAL-001)
Search transactions
### Testing for Stored Cross Site Scripting (OTG-INPVAL-002)
Add new account
### DOM XSS
??

## A4 Insecure Direct Object References

## A5 Security Misconfiguration

## A6 Sensitive Data Exposure
Not encrypted PCI Data
Weak hash on passwords?

## A7 Missing Function Level Access Control

## A8 Cross-Site Request Forgery (CSRF)
### Testing for Cross Site Request Forgery (CSRF) (OTG-SESS-005)
No CSRF-token on new payment
  
## A9 Using Components with Known Vulnerabilities

## A10 Unvalidated Redirects and Forwards
### Testing for Client Side URL Redirect (OTG-CLIENT-004)
ReturnURL after login