# Usa una imagen oficial de Node.js
FROM node:16

# Define el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia los archivos package.json y package-lock.json
COPY package*.json ./

# Instala las dependencias
RUN npm install

# Copia todo el código fuente de la aplicación
COPY . .

# Expón el puerto que usará el servidor de Angular (4200 por defecto)
EXPOSE 4200

# Comando para iniciar el servidor de desarrollo
CMD ["npm", "start"]
