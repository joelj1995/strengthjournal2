FROM nginx AS base

EXPOSE 80
EXPOSE 443

COPY server/nginx-selfsigned.crt /etc/ssl/certs/nginx-selfsigned.crt
COPY server/nginx-selfsigned.key /etc/ssl/private/nginx-selfsigned.key

RUN rm /etc/nginx/nginx.conf /etc/nginx/conf.d/default.conf
COPY server/nginx.conf /etc/nginx/nginx.conf
COPY server/devserver.conf /etc/nginx/conf.d/devserver.conf

FROM node:18 AS build
WORKDIR /usr/src
COPY . app
WORKDIR /usr/src/app
RUN npm install
RUN npm run build

FROM base AS final
COPY --from=build /usr/src/app/dist/journal-app/browser /usr/share/nginx/html/app

CMD ["nginx", "-g", "daemon off;"]