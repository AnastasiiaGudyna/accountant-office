FROM node:14-alpine as build-step
 
RUN mkdir -p /app
WORKDIR /app
COPY . /app
RUN npm install
RUN npm run build

FROM nginx:1.17.1-alpine

COPY --from=build-step /app/dist/accountant-office-front /usr/share/nginx/html

# Expose port 80
EXPOSE 80