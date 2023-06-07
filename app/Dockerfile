FROM node:lts-alpine3.18 as build-step
WORKDIR /app
COPY package.json package-lock.json /app/
RUN npm ci --production --legacy-peer-deps
COPY . /app
RUN npm run build
FROM nginx
COPY --from=build-step /app/build /usr/share/nginx/html

# COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

# Comando de inicio para ejecutar Nginx
CMD ["nginx", "-g", "daemon off;"]
