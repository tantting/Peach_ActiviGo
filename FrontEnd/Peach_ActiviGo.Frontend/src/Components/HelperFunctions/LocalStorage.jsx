/***
 * Sparar data i localStorage med en timestamp
 * @param {string} key - Nyckeln för localStorage
 * @param {any} data - Data som ska sparas
 */

export const saveLocalStorage = (key, data) => {
  try {
    const cacheData = {
      timestamp: Date.now(),
      data: data,
    };
    localStorage.setItem(key, JSON.stringify(cacheData));
  } catch (error) {
    console.error("Fel vid sparande till localStorage:", error);
  }
};

/**
 * Hämtar data från localStorage
 * @param {string} key - Nyckeln för localStorage
 * @returns {any|null} - Returnerar data om den finns, annars null
 */

export const getLocalStorage = (key) => {
  try {
    const cached = localStorage.getItem(key);

    if (!cached) {
      console.log(`Ingen permanent data hittad för ${key}`);
      return null;
    }

    const data = JSON.parse(cached);
    console.log(`Data hämtad för: ${key}`);
    return data;
  } catch (error) {
    console.error("Fel vid läsning av data från localStorage:", error);
    return null;
  }
};

/**
 * Hämtar tidsbegränsad data från localStorage och kontrollerar om den är giltig
 * @param {string} key - Nyckeln för localStorage
 * @param {number} maxAge - Maximal ålder i millisekunder
 * @returns {Object|null} - Returnerar data om den är giltig, annars null
 */

export const getTimedCache = (key, maxAge) => {
  try {
    const cached = localStorage.getItem(key);

    if (!cached) {
      console.log(`Ingen cache hittad för ${key}`);
      return null;
    }

    const { timestamp, data } = JSON.parse(cached);
    const timeSinceTimestamp = Date.now() - timestamp;
    const isFresh = timeSinceTimestamp < maxAge;

    if (isFresh) {
      console.log(
        `Laddade ${key} från cache (ålder: ${Math.round(
          timeSinceTimestamp / 1000 / 60
        )}m ${Math.round((timeSinceTimestamp % (1000 * 60)) / 1000)}s)`
      );
      return data;
    } else {
      console.log(
        `Cache för ${key} är för gammal (ålder: ${Math.round(
          timeSinceTimestamp / 1000 / 60
        )}m ${Math.round((timeSinceTimestamp % (1000 * 60)) / 1000)}s)`
      );
      console.log(`Hämtar ny data...`);
      return null;
    }
  } catch (error) {
    console.error("Fel vid läsning från localStorage:", error);
    return null;
  }
};
