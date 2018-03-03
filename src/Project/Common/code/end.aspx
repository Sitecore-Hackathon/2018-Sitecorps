<%@ Page language="c#" %>
<script runat="server">
  void Page_Load(object sender, System.EventArgs e) {
      Sitecore.Analytics.Tracker.Current.EndTracking();
      Session.Abandon();
  }
</script> 
<!DOCTYPE html>
<html>
  <head>
    <title>Session Abandon</title>
  </head>
  <body>
      <p>Session terminated. Contact data will now be committed to xConnect. <a href="/">Return home</a></p>
  </body>
</html>