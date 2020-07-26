FROM node:12-alpine as build
WORKDIR /myapp
EXPOSE 4200
COPY "package.json" .
RUN npm install
COPY . .
RUN npm run build --prod

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=build ./myapp/dist /usr/share/nginx/html
COPY ./config/nginx/default.conf /etc/nginx/conf.d/default.conf

