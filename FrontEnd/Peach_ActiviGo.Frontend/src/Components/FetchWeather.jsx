import React from 'react'
import { useState, useEffect } from 'react'

const WEATHER_API_KEY = import.meta.env.VITE_WEATHER_API_KEY;

const FetchWeather = () => {
const [weather, setWeather] = useState(null)

  useEffect(() => {
    const fetchWeatherData = async () => {
      try {
        const response = await fetch(`https://api.openweathermap.org/data/2.5/weather?q=Varberg,SE&appid=${WEATHER_API_KEY}&units=metric&lang=sv`)
        const data = await response.json()
        console.log(data)

        setWeather(data)

      } catch (error) 
      {
        console.error('Fetch error:', error)
      }
    }

    fetchWeatherData()
  }, [])

  return (
    <div>
      {weather ? (
        <div>
          <h2>Weather in {weather.name}</h2>
          <p>Temperature: {weather.main.temp}°C</p>
          <p>Condition: {weather.weather[0].description}</p>
          <p>Feels like: {weather.main.feels_like}°C</p>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  )
}

export default FetchWeather