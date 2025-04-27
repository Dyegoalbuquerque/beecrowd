#!/bin/bash
until pg_isready -h db -p 5432; do
  echo "Waiting for the database to be ready..."
  sleep 2
done
echo "Database already. Starting API..."
exec "$@"
