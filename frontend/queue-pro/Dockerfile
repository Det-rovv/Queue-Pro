FROM node:18-alpine

WORKDIR /app

# Установка зависимостей

COPY package*.json ./
COPY tsconfig.json ./
COPY vite.config.* ./

RUN npm install

# Копирование проекта
COPY . .

# Сборка проекта (если нужно)
RUN npm run build

EXPOSE 4173

# Запуск сервера разработки (или serve для production)
CMD ["npm", "start"]

