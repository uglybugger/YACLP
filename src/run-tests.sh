#!/bin/bash

dotnet test --logger:trx --output ${TEST_RESULTS_PATH:TestResults}
