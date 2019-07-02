# Tests

You can start tests by running this command.

```
python -m unittest discover neo
```

Note that some of the unit tests use a giant blockchain fixture database ( around 800mb ). This file is not kept in the repository.

When running tests the first time, the test setup will try to download the file and extract it to the proper directory.

**Long story short**: the first time you run your tests, it will take a while to download those fixtures. After that it should be pretty quick.

To run tests with `coverage`, use the following

```
coverage run -m unittest discover neo

```

After that, you can generate a command line coverage report use the following:

```
coverage report -m --omit=venv/*
```