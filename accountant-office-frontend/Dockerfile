FROM node:14-alpine as build-step
 
RUN mkdir -p /app
WORKDIR /app
COPY . /app
RUN npm install
RUN npm run build --prod

FROM nginx:latest

COPY --from=build-step /app/dist/accountant-office-front /usr/share/nginx/html