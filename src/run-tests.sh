#!/bin/bash

dotnet test --logger:trx --results-directory ${TEST_RESULTS_PATH:TestResults}
