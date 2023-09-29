static void ParseNotificationChannel(string notification) {
  string[] notificationChannels = {"BE", "FE", "QA", "Urgent"};
  List<string> foundChannels = new();

  string channel = "";
  bool isOpenTag = false;
  for (int i = 0; i < notification.Length; i++) {
    char c = notification[i];

    if (c == '[') {
      channel = "";
      isOpenTag = true;
      continue;
    } else if (c == ']') {
      if (!string.IsNullOrEmpty(channel) && notificationChannels.Contains(channel)) {
        foundChannels.Add(channel);
      }
      channel = "";
      isOpenTag = false;
      continue;
    }

    if (isOpenTag) {
      channel += c;
    }
  }

  Console.WriteLine("Receive channels: " + string.Join(", ", foundChannels));
}

ParseNotificationChannel("[BE][FE][Urgent] there is error");
ParseNotificationChannel("[BE][QA][HAHA][Urgent] there is error");