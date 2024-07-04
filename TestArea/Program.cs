string path = "./example.xml";
XMLManipulator manipulator = new(path);
await manipulator.ReadAsync();
