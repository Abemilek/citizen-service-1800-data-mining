#!/bin/bash
OUTPUT_FILE="notebooks_summary.md"
echo "# Resumen de Notebooks y Resultados" > $OUTPUT_FILE
echo "A continuación se muestra el código y resultado exacto de cada notebook ejecutado en tiempo real." >> $OUTPUT_FILE

for f in DataSetGenerator/citizen-analytics/notebooks/*.ipynb; do
  md_file="${f%.ipynb}.md"
  if [ -f "$md_file" ]; then
    echo -e "\n\n## Archivo: $(basename $f)\n" >> $OUTPUT_FILE
    cat "$md_file" >> $OUTPUT_FILE
  fi
done
