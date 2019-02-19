#!/bin/bash

set -e
run_cmd="dotnet watch run --urls http://0.0.0.0:80"

cd DiscoCordAPI.Web.Api
until dotnet ef database update; do
>&2 echo "SQL Server connecting..."
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd