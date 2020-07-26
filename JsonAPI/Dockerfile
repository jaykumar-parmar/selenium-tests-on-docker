FROM node:12-alpine
WORKDIR /myapp
RUN npm install -g json-server
EXPOSE 3000
COPY . .
ENTRYPOINT [ "json-server", "--watch", "data.json" , "-H", "0.0.0.0"]












